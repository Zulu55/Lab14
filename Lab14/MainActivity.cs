using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab14
{
    [Activity(Label = "Lab14", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        EditText editTextEmail;
        EditText editTextPassword;
        Button buttonValidate;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            editTextEmail = FindViewById<EditText>(Resource.Id.editTextEmail);
            editTextPassword = FindViewById<EditText>(Resource.Id.editTextPassword);
            buttonValidate = FindViewById<Button>(Resource.Id.buttonValidate);

            buttonValidate.Click += ButtonValidate_Click;
        }

        private async void ButtonValidate_Click(object sender, System.EventArgs e)
        {
            var client = new SALLab14.ServiceClient();
            var result = await client.ValidateAsync(this);
            var builder = new AlertDialog.Builder(this);
            var alert = builder.Create();
            alert.SetTitle("Resultado de la verificación");
            alert.SetIcon(Resource.Drawable.Icon);
            alert.SetMessage($"{result.Status}\n{result.FullName}\n{result.Token}");
            alert.SetButton("Ok", (s, ev) => { });
            alert.Show();
        }
    }
}

