using Android.App;
using Android.OS;
using Android.Views;

namespace SamplerApp
{
    public class WelcomeFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.welcome_fragment, container, false);
            return view;
        }
    }
}