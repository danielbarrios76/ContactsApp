# ContactsApp

Una aplicacion simple para mostrar el uso de MVVM con Xamarin.Form con la estrategia PCL.


No esta incluido el proyecto iOS por que no tengo una Mac para compilar, pero no deberia tener problemas
en funcionar tambien.


Descripcion:

La solucion consta de 3 proyectos:

*1_ ContactsApp

*2_ ContactsApp.Android

*3_ ContactsApp.UWP

**No se incluye el proyecto .iOS


Los proyectos .Android y . UWP no tienen modificaciones con respecto a la plantilla de Visual Studio

Elproyecto ContactsApp es el PCL y contiene el Model, el ViewModels y la View, que en este caso es la MainPage Unica para los proyectos

En Model tenemos la Clase Plana Contact, que tiene 2 simples propiedades publicas name e email.

En ViewModels tenemos la Clase AddContactViewModels, que es la que interactura con la View.

La MainPage.XAML es la View que hace los llamados a la ViewModels depediendo de las acciones del usuario.

Un ejemplo cortito y simple.
