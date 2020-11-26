using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Auth.Api;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common;
using Android.Gms.Common.Apis;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SampleApp.Droid;
using SampleApp.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(GoogleManager))]
namespace SampleApp.Droid
{
	public class GoogleManager : Java.Lang.Object, IGoogleManager, GoogleApiClient.IConnectionCallbacks, GoogleApiClient.IOnConnectionFailedListener
	{
		public Action<GoogleUser, string> _onLoginComplete;
		public static GoogleApiClient _googleApiClient { get; set; }
		public static GoogleManager Instance { get; private set; }
		Context _context;

		public GoogleManager()
		{
			_context = global::Android.App.Application.Context;
			Instance = this;
		}

		public void Login(Action<GoogleUser, string> onLoginComplete)
		{
			GoogleSignInOptions gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn)
															 .RequestEmail()
															 .Build();
			_googleApiClient = new GoogleApiClient.Builder((_context).ApplicationContext)
				.AddConnectionCallbacks(this)
				.AddOnConnectionFailedListener(this)
				.AddApi(Auth.GOOGLE_SIGN_IN_API, gso)
				.AddScope(new Scope(Scopes.Profile))
				.Build();

			_onLoginComplete = onLoginComplete;
			Intent signInIntent = Auth.GoogleSignInApi.GetSignInIntent(_googleApiClient);
			((MainActivity)Forms.Context).StartActivityForResult(signInIntent, 1);
			_googleApiClient.Connect();
		}

		public void Logout()
		{
			var gsoBuilder = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn).RequestEmail();

			GoogleSignIn.GetClient(_context, gsoBuilder.Build())?.SignOut();

			_googleApiClient.Disconnect();

		}

		public void OnAuthCompleted(GoogleSignInResult result)
		{
			if (result.IsSuccess)
			{
				GoogleSignInAccount accountt = result.SignInAccount;
				_onLoginComplete?.Invoke(new GoogleUser()
				{
					Name = accountt.DisplayName,
					Email = accountt.Email,
					Picture = new Uri((accountt.PhotoUrl != null ? $"{accountt.PhotoUrl}" : $"https://autisticdating.net/imgs/profile-placeholder.jpg"))
				}, string.Empty);
			}
			else
			{
				_onLoginComplete?.Invoke(null, "An error occured!");
			}
		}

		public void OnConnected(Bundle connectionHint)
		{

		}

		public void OnConnectionSuspended(int cause)
		{
			_onLoginComplete?.Invoke(null, "Canceled!");
		}

		public void OnConnectionFailed(ConnectionResult result)
		{
			_onLoginComplete?.Invoke(null, result.ErrorMessage);
		}
	}
}