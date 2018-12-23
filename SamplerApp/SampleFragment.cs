using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;

namespace SamplerApp
{
    
    public class SampleFragment : Android.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        MediaPlayer playerOne;
        MediaPlayer playerTwo;
        MediaPlayer playerThree;
        MediaPlayer playerFour;
        MediaPlayer playerFive;
        MediaPlayer playerSix;
        MediaPlayer playerSeven;
        MediaPlayer playerEight;

        bool checkOne = true;
        bool checkTwo = true;
        bool checkThree = true;
        bool checkFour = true;
        bool checkFive = true;
        bool checkSix = true;
        bool checkSeven = true;
        bool checkEight = true;

        SeekBar seekBarOne;
        SeekBar seekBarTwo;
        SeekBar seekBarThree;
        SeekBar seekBarFour;
        SeekBar seekBarFive;
        SeekBar seekBarSix;
        SeekBar seekBarSeven;
        SeekBar seekBarEight;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.sample_fragment, container, false);

            Button btnOne = (Button)view.FindViewById<Button>(Resource.Id.btnOne);
            Button btnTwo = (Button)view.FindViewById<Button>(Resource.Id.btnTwo);
            Button btnThree = (Button)view.FindViewById<Button>(Resource.Id.btnThree);
            Button btnFour = (Button)view.FindViewById<Button>(Resource.Id.btnFour);
            Button btnFive = (Button)view.FindViewById<Button>(Resource.Id.btnFive);
            Button btnSix = (Button)view.FindViewById<Button>(Resource.Id.btnSix);
            Button btnSeven = (Button)view.FindViewById<Button>(Resource.Id.btnSeven);
            Button btnEight = (Button)view.FindViewById<Button>(Resource.Id.btnEight);

            Button btnFileOne = (Button)view.FindViewById<Button>(Resource.Id.btnFileOne);
            Button btnFileTwo = (Button)view.FindViewById<Button>(Resource.Id.btnFileTwo);
            Button btnFileThree = (Button)view.FindViewById<Button>(Resource.Id.btnFileThree);
            Button btnFileFour = (Button)view.FindViewById<Button>(Resource.Id.btnFileFour);
            Button btnFileFive = (Button)view.FindViewById<Button>(Resource.Id.btnFileFive);
            Button btnFileSix = (Button)view.FindViewById<Button>(Resource.Id.btnFileSix);
            Button btnFileSeven = (Button)view.FindViewById<Button>(Resource.Id.btnFileSeven);
            Button btnFileEight = (Button)view.FindViewById<Button>(Resource.Id.btnFileEight);

            seekBarOne = (SeekBar)view.FindViewById<SeekBar>(Resource.Id.seekBarOne);
            seekBarTwo = (SeekBar)view.FindViewById<SeekBar>(Resource.Id.seekBarTwo);
            seekBarThree = (SeekBar)view.FindViewById<SeekBar>(Resource.Id.seekBarThree);
            seekBarFour = (SeekBar)view.FindViewById<SeekBar>(Resource.Id.seekBarFour);
            seekBarFive = (SeekBar)view.FindViewById<SeekBar>(Resource.Id.seekBarFive);
            seekBarSix = (SeekBar)view.FindViewById<SeekBar>(Resource.Id.seekBarSix);
            seekBarSeven = (SeekBar)view.FindViewById<SeekBar>(Resource.Id.seekBarSeven);
            seekBarEight = (SeekBar)view.FindViewById<SeekBar>(Resource.Id.seekBarEight);

            btnOne.Click += delegate { Start(playerOne, checkOne); if (playerOne != null) { checkOne = !checkOne; } };
            btnTwo.Click += delegate { Start(playerTwo, checkTwo); if (playerTwo != null) { checkTwo = !checkTwo; } };
            btnThree.Click += delegate { Start(playerThree, checkThree); if (playerThree != null) { checkThree = !checkThree; } };
            btnFour.Click += delegate { Start(playerFour, checkFour); if (playerFour != null) { checkFour = !checkFour; } };
            btnFive.Click += delegate { Start(playerFive, checkFive); if (playerFive != null) { checkFive = !checkFive; } };
            btnSix.Click += delegate { Start(playerSix, checkSix); if (playerSix != null) { checkSix = !checkSix; } };
            btnSeven.Click += delegate { Start(playerSeven, checkSeven); if (playerSeven != null) { checkSeven = !checkSeven; } };
            btnEight.Click += delegate { Start(playerEight, checkEight); if (playerEight != null) { checkEight = !checkEight; } };

            btnFileOne.Click += delegate { SetContent((int)Request.btnFileOne, playerOne); };
            btnFileTwo.Click += delegate { SetContent((int)Request.btnFileTwo, playerTwo); };
            btnFileThree.Click += delegate { SetContent((int)Request.btnFileThree, playerThree); };
            btnFileFour.Click += delegate { SetContent((int)Request.btnFileFour, playerFour); };
            btnFileFive.Click += delegate { SetContent((int)Request.btnFileFive, playerFive); };
            btnFileSix.Click += delegate { SetContent((int)Request.btnFileSix, playerSix); };
            btnFileSeven.Click += delegate { SetContent((int)Request.btnFileSeven, playerSeven); };
            btnFileEight.Click += delegate { SetContent((int)Request.btnFileEight, playerEight); };

            seekBarOne.ProgressChanged += delegate { if (playerOne != null) { SetVolume(playerOne, seekBarOne); } };
            seekBarTwo.ProgressChanged += delegate { if (playerTwo != null) { SetVolume(playerTwo, seekBarTwo); } };
            seekBarThree.ProgressChanged += delegate { if (playerThree != null) { SetVolume(playerThree, seekBarThree); } };
            seekBarFour.ProgressChanged += delegate { if (playerFour != null) { SetVolume(playerFour, seekBarFour); } };
            seekBarFive.ProgressChanged += delegate { if (playerFive != null) { SetVolume(playerFive, seekBarFive); } };
            seekBarSix.ProgressChanged += delegate { if (playerSix != null) { SetVolume(playerSix, seekBarSix); } };
            seekBarSeven.ProgressChanged += delegate { if (playerSeven != null) { SetVolume(playerSeven, seekBarSeven); } };
            seekBarEight.ProgressChanged += delegate { if (playerEight != null) { SetVolume(playerEight, seekBarEight); } };

            return view;
        }

        private void Start(MediaPlayer player, bool check)
        {
            if (check == true && player != null)
            {
                player.Start();
                player.Looping = true;
            }
            else if (check == false && player != null)
            { 
                player.Pause();
            }
            else if(player==null)
            {
               Snackbar.Make(this.View, "Please select a file.", Snackbar.LengthLong).Show();
            }
        }

        private void SetVolume(MediaPlayer player, SeekBar seekBar)
        {
            float progress = seekBar.Progress;
            progress /= 100;
            player.SetVolume(progress, progress);
        }

        void SetContent(int save_request_code, MediaPlayer player)
        {
            if (player == null || player.IsPlaying==false)
            {
                Intent intent = new Intent(Intent.ActionOpenDocument);
                intent.AddCategory(Intent.CategoryOpenable);
                intent.SetType("*/*");
                StartActivityForResult(intent, save_request_code);
            }
            else if(player.IsPlaying==true)
            {
                Snackbar.Make(this.View, "Please pause currently playing track.", Snackbar.LengthLong).Show();
            }
        }

        public override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if (resultCode == Result.Ok && data != null && requestCode == (int)Request.btnFileOne)
            {
                playerOne = MediaPlayer.Create(this.Activity, data.Data);
            }

            if (resultCode == Result.Ok && data != null && requestCode == (int)Request.btnFileTwo)
            {
                playerTwo = MediaPlayer.Create(this.Activity, data.Data);
            }

            if (resultCode == Result.Ok && data != null && requestCode == (int)Request.btnFileThree)
            {
                playerThree = MediaPlayer.Create(this.Activity, data.Data);
            }

            if (resultCode == Result.Ok && data != null && requestCode == (int)Request.btnFileFour)
            {
                playerFour = MediaPlayer.Create(this.Activity, data.Data);
            }

            if (resultCode == Result.Ok && data != null && requestCode == (int)Request.btnFileFive)
            {
                playerFive = MediaPlayer.Create(this.Activity, data.Data);
            }

            if (resultCode == Result.Ok && data != null && requestCode == (int)Request.btnFileSix)
            {
                playerSix = MediaPlayer.Create(this.Activity, data.Data);
            }

            if (resultCode == Result.Ok && data != null && requestCode == (int)Request.btnFileSeven)
            {
                playerSeven = MediaPlayer.Create(this.Activity, data.Data);
            }

            if (resultCode == Result.Ok && data != null && requestCode == (int)Request.btnFileEight)
            {
                playerEight = MediaPlayer.Create(this.Activity, data.Data);
            }
        }
    }
}