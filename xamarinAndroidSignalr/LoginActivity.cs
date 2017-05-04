using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.View;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
namespace xamarinAndroidSignalr
{
    [Activity(Label = "xamarinAndroidSignalr", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MyTheme")]
    public class LoginActivity : AppCompatActivity
    {
        private TextView tv_goreg;
        private TextInputLayout accountContainer;
        private TextInputLayout passWordContainer;
        private Button btnLogin;
        private EventHandler goregClick;
        private const string accountError = "用户名是4-16中文字母数字符号./_等组成";
        private const string pwdError = "密码是6-16中文字母数字符号./_等组成";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LoginActivity);
            tv_goreg = FindViewById<TextView>(Resource.Id.tv_goreg);
            accountContainer = FindViewById<TextInputLayout>(Resource.Id.accountContainer);
            passWordContainer = FindViewById<TextInputLayout>(Resource.Id.passWordContainer);
            btnLogin = FindViewById<Button>(Resource.Id.btn_login);
            StatusBarUtil.ColorStatusBar(this,Resources.GetColor(Resource.Color.color_primary));

            btnLogin.Enabled = false;
            btnLogin.Click += btnLogin_Click;
            tv_goreg.Click += (s, e) =>
            {
                Intent intent = new Intent(this, typeof(RegisterActivity));
                StartActivity(intent);
            };

            accountContainer.EditText.FocusChange += (s, e) =>
            {
                if (!e.HasFocus)
                {
                    if (!checkAccount(accountContainer.EditText.Text))
                    {
                        accountContainer.ErrorEnabled = true;
                        accountContainer.Error = accountError;
                    }
                    else
                    {
                        accountContainer.ErrorEnabled = false;
                    }
                }
            };

            passWordContainer.EditText.FocusChange += (s, e) =>
            {
                if (!e.HasFocus)
                {
                    if (!checkPwd(passWordContainer.EditText.Text))
                    {
                        passWordContainer.ErrorEnabled = true;
                        passWordContainer.Error = pwdError;
                    }
                    else
                    {
                        passWordContainer.ErrorEnabled = false;
                    }
                }
            };

            accountContainer.EditText.TextChanged += (s, e) =>
            {
                System.Diagnostics.Debug.WriteLine(e.Start);
                if (e.Start >= 3)
                {
                    if (accountContainer.ErrorEnabled == false && !checkAccount(e.Text.ToString()))
                    {
                        accountContainer.ErrorEnabled = true;
                        accountContainer.Error = accountError;
                    }
                    else
                    {
                        accountContainer.ErrorEnabled = false;
                    }
                    checkBtnStatus();
                }
            };

            passWordContainer.EditText.TextChanged += (s, e) =>
            {
                if (e.Start >= 5)
                {
                    if (passWordContainer.ErrorEnabled == false && !checkPwd(e.Text.ToString()))
                    {
                        passWordContainer.ErrorEnabled = true;
                        passWordContainer.Error = pwdError;
                    }
                    else
                    {
                        passWordContainer.ErrorEnabled = false;
                    }
                    checkBtnStatus();
                }
            };
            // Create your application here
        }
        private void btnLogin_Click(object sender,EventArgs e)
        {
            var progressDialog = ProgressDialog.Show(this,"登录中","正在登录请稍后.....");
            Client.Login(accountContainer.EditText.Text, passWordContainer.EditText.Text, () => RunOnUiThread(() =>
            {
                btnLogin.Enabled = true;
                LoginSuccessEvent();
                progressDialog.Hide();
            }), r => RunOnUiThread(() =>
            {
                MessageUtils.ToastLong(this,r);
                btnLogin.Enabled = true;
                progressDialog.Hide();
            }));
        }

        private void LoginSuccessEvent()
        {
            MessageUtils.ToastLong(this, "登录成功");
            Intent intent = new Intent(this,typeof(MainActivity));
            StartActivity(intent);
        }
        /// <summary>
        /// 检查用户名
        /// </summary>
        private bool checkAccount(string  account)
        {
            string pattern = @"^(?!_)[\u4e00-\u9fa5\da-zA-Z._/]{4,16}$";
            if (System.Text.RegularExpressions.Regex.IsMatch(account, pattern))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        ///检查密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        private bool checkPwd(string  pwd)
        {
            string pattern = @"^(?!_)[\da-zA-Z._/]{6,16}$";
            if (System.Text.RegularExpressions.Regex.IsMatch(pwd,pattern))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 根据输入信息是否正确判断登录按钮是否可用
        /// </summary>
        private void checkBtnStatus()
        {
            if (accountContainer.ErrorEnabled == false && passWordContainer.ErrorEnabled == false)
            {
                btnLogin.Enabled = true;
                Android.Graphics.Color color = Resources.GetColor(Resource.Color.color_primary);
                btnLogin.SetTextColor(Resources.GetColor(Resource.Color.color_primary));
                btnLogin.SetBackgroundColor(Resources.GetColor(Resource.Color.color_white));
            }
            else
            {
                btnLogin.Enabled = false;
                btnLogin.SetTextColor(Resources.GetColor(Resource.Color.color_black));
                btnLogin.SetBackgroundColor(Resources.GetColor(Resource.Color.color_dedede));
            }
        }
    }
}