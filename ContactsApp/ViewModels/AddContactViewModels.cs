using ContactsApp.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactsApp.ViewModels
{
    /// <summary>
    /// Contiene la logica de la aplicacion
    /// </summary>
    class AddContactViewModels : INotifyPropertyChanged
    {
        //instancia de la clase plana del modelo
        Contact contact;

        //booleano que nos servira para determinar si la aplicacion esta realizando alguna tarea
        bool isBusy = false;

        //Para detectar cambios en la vista ante la interaccion del ususario
        public event PropertyChangedEventHandler PropertyChanged;

        //Comando que llamara al metodo que guarda los datos del contacto
        public Command SaveContactCommand { get; }

        //metodo que realiza la accion ante un cambio en la vista
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// Constructor
        /// Creamos un objeto contacto con cadenas vacias para ahi leer los datos de la vista
        /// </summary>
        public AddContactViewModels()
        {
            contact = new Contact
            {
                name = string.Empty,
                email = string.Empty
            };
            
            //comando para guardar los datos
            SaveContactCommand = new Command(async () => await SaveContact(), () => !IsBusy);
        }
        
        //propiedades
        public string Name
        {
            get { return contact.name; }
            set
            {
                contact.name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }

        public string Email
        {
            get { return contact.email; }
            set
            {
                contact.email = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
                SaveContactCommand.ChangeCanExecute();
            }
        }


        /// <summary>
        /// Muestra los datos mientras se van cargando
        /// una forma de ver como funcionan los Binding de la vista
        /// </summary>
        public string DisplayMessage
        {
            get { return $"Name: {contact.name} - Email: {contact.email}"; }
        }

        async Task SaveContact()
        {
            //El codigo para guardar un contacto
            //Se emula una demora y se muestra un mesaje simple de que se guardo el contacto
            IsBusy = true;

            await Task.Delay(4000);

            IsBusy = false;

            await Application.Current.MainPage.DisplayAlert("Save", $"Contact {contact.name} has saved", "Ok");

        }

     //end class AddContactViewModels   
    }
}
