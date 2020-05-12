using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinNotes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var notes = new List<Note>();

            foreach (var fileName in FileManager.AllFiles())
            {
                var note = new Note() { FileName = fileName };
                note.FromString(FileManager.LoadText(fileName));
                notes.Add(note);
            }

            noteView.ItemsSource = notes.OrderBy(d => d.CreationDate).ToList();
        }

        async void ButtonAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoteEntryPage()
            {
                BindingContext = new Note()
            });
        }

        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NoteEntryPage()
                {
                    BindingContext = e.SelectedItem as Note
                });
            }
        }
    }
}