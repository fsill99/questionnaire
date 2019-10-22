using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using QuestionnaireLib;

namespace DbListviewWinformControl
{
    public class DbListview : ListView
    {
        private Type _dbEntityType;
        private PropertyInfo[] _properties;
        private bool _displayGuids;

        //Il tipo di entità db associata al controllo.
        public Type DbEntityType
        {
            get
            {
                if (_dbEntityType == null)
                    _dbEntityType = typeof(Object);
                return _dbEntityType;
            }
            set
            {
                //Quando il tipo viene assegnato o cambia, le proprietà vengono aggiornate.
                _dbEntityType = value;
                _properties = _dbEntityType.GetProperties();
            }
        }

        public PropertyInfo[] Properties
        {
            get
            {
                if(!DisplayGuids)
                {
                    return _properties.Where(p => p.PropertyType != typeof(Guid)).ToArray();
                }
                return _properties;
            }
            set
            {
                if(value != null)
                    _properties = value;
            }
        }

        //Proprietà che specifica se far visualizzare i Guid nel controllo.
        public bool DisplayGuids
        {
            get
            {
                return _displayGuids;
            }
            set
            {
                _displayGuids = value;
            }
        }

        public DbListview() : base()
        {
            //Se non viene specificato successivamente, i Guid sono automaticamente nascosti.
            _displayGuids = false;

            //Configuriamo alcune impostazioni della listview da codice.
            View = System.Windows.Forms.View.Details;
            FullRowSelect = true;
        }

        public async void Populate()
        {
            Items.Clear();
            //aggiungiamo le colonne
            _setColumns();
            
            //questa variabile rappresenta il metodo statico GetAllAsync della classe associata al nostro controllo
            MethodInfo getAllAsyncMethod = DbEntityType.GetMethod("GetAllAsync", BindingFlags.Public | BindingFlags.Static);

            ListViewItem item;
            ListViewItem.ListViewSubItem subItem;
            object propertyValue;

            //Chiamiamo il metodo asincrono GetAllAsync.
            //Facendo il cast con il tipo "dynamic" indichiamo al compilatore che il tipo dell'oggetto restituito
            //sarà determinato solo quando il codice sarà eseguito.
            //Sappiamo, però, che sarà una collezione enumerabile di oggetti che implementano l'interfaccia IDbEntity,
            //ovvero oggetti che rispecchiano tabelle nel database.
            IEnumerable<IDBEntity> result = await (dynamic)getAllAsyncMethod.Invoke(null, null);

            //TODO: check for display properties before iterating through them
            foreach (IDBEntity dbEntity in result)
            {
                item = new ListViewItem();
                //Prendiamo il valore della prima proprietà
                propertyValue = Properties[0].GetValue(dbEntity);
                item.Text = propertyValue == null ? "" : propertyValue.ToString();

                //Ripetiamo il procedimento per le altre proprietà dell'oggetto
                for (int i = 1; i < Properties.Count(); i++)
                {
                    subItem = new ListViewItem.ListViewSubItem();
                    propertyValue = Properties[i].GetValue(dbEntity);
                    subItem.Text = propertyValue == null ? "" : propertyValue.ToString();
                    item.SubItems.Add(subItem);
                }

                item.Tag = dbEntity;
                Items.Add(item);
            }

            //Le colonne devono adattarsi al contenuto delle celle.
            AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void _setColumns()
        {
            Columns.Clear();
            //Per ogni proprietà del tipo di oggetto associato a questo controllo, aggiungiamo
            //una colonna al nostro controllo.
            foreach (PropertyInfo p in Properties)
            {
                Columns.Add(p.Name);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        #region NON CONSIDERARE QUESTO METODO PER LA PRESENTAZIONE
        public async void Populate(Func<IDBEntity, bool> wherePredicate)
        {
            Items.Clear();
            //aggiungiamo le colonne
            _setColumns();

            //questa variabile rappresenta il metodo statico GetAllAsync della classe associata al nostro controllo
            MethodInfo getAllAsyncMethod = DbEntityType.GetMethod("GetAllAsync", BindingFlags.Public | BindingFlags.Static);

            ListViewItem item;
            ListViewItem.ListViewSubItem subItem;
            object propertyValue;

            //Chiamiamo il metodo asincrono GetAllAsync.
            //Facendo il cast con il tipo "dynamic" indichiamo al compilatore che il tipo dell'oggetto restituito
            //sarà determinato solo quando il codice sarà eseguito.
            //Sappiamo, però, che sarà una collezione enumerabile di oggetti che implementano l'interfaccia IDbEntity,
            //ovvero oggetti che rispecchiano tabelle nel database.
            IEnumerable<IDBEntity> result = await (dynamic)getAllAsyncMethod.Invoke(null, null);

            //TODO: check for display properties before iterating through them
            foreach (IDBEntity dbEntity in result.Where(wherePredicate))
            {
                item = new ListViewItem();
                //Prendiamo il valore della prima proprietà
                propertyValue = Properties[0].GetValue(dbEntity);
                item.Text = propertyValue == null ? "" : propertyValue.ToString();

                //Ripetiamo il procedimento per le altre proprietà dell'oggetto
                for (int i = 1; i < Properties.Count(); i++)
                {
                    subItem = new ListViewItem.ListViewSubItem();
                    propertyValue = Properties[i].GetValue(dbEntity);
                    subItem.Text = propertyValue == null ? "" : propertyValue.ToString();
                    item.SubItems.Add(subItem);
                }

                item.Tag = dbEntity;
                Items.Add(item);
            }

            //Le colonne devono adattarsi al contenuto delle celle.
            AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        #endregion

        #region NON CONSIDERARE QUESTO METODO PER LA PRESENTAZIONE
        public void Populate(dynamic objects)
        {
            Items.Clear();
            //aggiungiamo le colonne
            _setColumns();

            ListViewItem item;
            ListViewItem.ListViewSubItem subItem;
            object propertyValue;
            IEnumerable<IDBEntity> result = objects;

            //TODO: check for display properties before iterating through them
            foreach (IDBEntity dbEntity in result)
            {
                item = new ListViewItem();
                //Prendiamo il valore della prima proprietà
                propertyValue = Properties[0].GetValue(dbEntity);
                item.Text = propertyValue == null ? "" : propertyValue.ToString();

                //Ripetiamo il procedimento per le altre proprietà dell'oggetto
                for (int i = 1; i < Properties.Count(); i++)
                {
                    subItem = new ListViewItem.ListViewSubItem();
                    propertyValue = Properties[i].GetValue(dbEntity);
                    subItem.Text = propertyValue == null ? "" : propertyValue.ToString();
                    item.SubItems.Add(subItem);
                }

                item.Tag = dbEntity;
                Items.Add(item);
            }

            //Le colonne devono adattarsi al contenuto delle celle.
            AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        #endregion
    }
}
