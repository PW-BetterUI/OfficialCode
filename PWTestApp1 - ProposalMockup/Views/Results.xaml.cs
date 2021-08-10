using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PWTestApp1___ProposalMockup.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	
	public partial class Results : ContentPage
	{
		private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
		private static readonly string ApplicationName = "Test";
		private static readonly string SpreadsheetId = "1w7bPa_hrH382oVPDwIW9EotY-rzHcj8VHBesYPHPNEg";
		private static SheetsService service;

		private static readonly string examResultsTestSheet = "Exam Results (Tests)";
		private static readonly string examResultsOPSheet = "Exam Results (OP)";

		private List<string> term1OPResults = new List<string>();
		private List<string> term2OPResults = new List<string>();
		private List<string> term1TestResults = new List<string>();
		private List<string> term2TestResults = new List<string>();

		private List<string> opResultsHeaders = new List<string>();
		private List<string> testResultsHeaders = new List<string>();
			
		public static string userId = LoginPage.userId;

		public Results ()
		{
			InitializeComponent ();

			ResetPicker();
		}

		private void ResetPicker()
        {
			ResultsPicker.Items.Clear();

			ResultsPicker.Items.Add("Term 1: Oral Presentation");
			ResultsPicker.Items.Add("Term 2: Oral Presentation");
			ResultsPicker.Items.Add("Term 1: Test");
			ResultsPicker.Items.Add("Term 2: Test");
		}

		private async void CredentialsInit()
		{
			GoogleCredential credential;

			credential = GoogleCredential.FromStream(await FileSystem.OpenAppPackageFileAsync("clientSecrets.json"))
				.CreateScoped(Scopes);

			service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
			{
				HttpClientInitializer = credential,
				ApplicationName = ApplicationName,
			});
		}

		private async void CheckResult(string scope)
        {
			CredentialsInit();

			var range = $"{examResultsOPSheet}!A1:I";
			var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);

			var response = request.Execute();
			var values = response.Values;

			var range_ = $"{examResultsTestSheet}!A:J";
			var request_ = service.Spreadsheets.Values.Get(SpreadsheetId, range_);

			var response_ = request_.Execute();
			var values_ = response_.Values;

			term1OPResults.Clear();
			term2OPResults.Clear();
			term1TestResults.Clear();
			term2TestResults.Clear();

			opResultsHeaders.Clear();
			testResultsHeaders.Clear();

			int x = 0;
			foreach (var r in values[0])
			{
				if(x > 1)
                {
					opResultsHeaders.Add(r.ToString());
                }

				x++;
			}

			int y = 0;
			foreach(var r in values_[0])
            {
				if(y > 1)
                {
					testResultsHeaders.Add(r.ToString());
                }

				y++;
            }


			if (scope == "Term 1: Oral Presentation")
            {
				foreach(var row in values)
                {
                    if (row[0].ToString() == userId)
                    {
						if (int.Parse(row[1].ToString()) == 1)
						{
							for (int i = 2; i < row.Count(); i++)
							{
								term1OPResults.Add(row[i].ToString());
							}
						}
                    }
				}

				Console.WriteLine("term 1 op result yes");
            }
			else if(scope == "Term 2: Oral Presentation")
            {
				foreach(var row in values)
                {
					if(row[0].ToString() == userId)
                    {
						if(int.Parse(row[1].ToString()) == 2)
                        {
							for(int i = 2; i < row.Count(); i++)
                            {
								term2OPResults.Add(row[i].ToString());
                            }
                        }
                    }
                }

				Console.WriteLine("term 2 op yes");
            }
			else if(scope == "Term 1: Test")
            {
				foreach(var row in values_)
                {
					if(row[0].ToString() == userId)
                    {
						if(int.Parse(row[1].ToString()) == 1)
                        {
							for(int i = 2; i < row.Count(); i++)
                            {
								term1TestResults.Add(row[i].ToString());
                            }
                        }
                    }
                }

				Console.WriteLine("term 1 test yes");
            }
			else if(scope == "Term 2: Test")
            {
				foreach(var row in values_)
                {
					if(row[0].ToString() == userId)
                    {
                        if (int.Parse(row[1].ToString()) == 2)
                        {
							for(int i = 2; i < row.Count(); i++)
                            {
								term2TestResults.Add(row[i].ToString());
                            }
                        }
                    }
                }

				Console.WriteLine("term 2 test yes");
            }
        }

		async void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
			var picker = (Picker)sender;
			int selectedIndex = picker.SelectedIndex;

			if(selectedIndex != -1)
            {
				await Task.Run(() => CheckResult(picker.Items[selectedIndex]));

				string scope = picker.Items[selectedIndex];

				ResultsStackLayout.Children.Clear();

				Console.WriteLine(term1OPResults.Count());

				if (scope == "Term 1: Oral Presentation")
				{
					int i = 0;
					foreach(string result in term1OPResults)
					{
						if (result != "-")
						{
							var resultLabel = new Label { Text = $"{opResultsHeaders[i]}: {result}", Margin = new Thickness(5, 0, 0, 0) };
							resultLabel.SetAppThemeColor(Label.TextColorProperty, Color.Black, Color.White);

							ResultsStackLayout.Children.Add(resultLabel);
						}

						i++;
					}
				}
				else if (scope == "Term 2: Oral Presentation")
				{
					int i = 0;
					foreach(string result in term2OPResults)
					{
						if (result != "-")
						{
							var resultLabel = new Label { Text = $"{opResultsHeaders[i]}: {result}", Margin = new Thickness(5, 0, 0, 0) };
							resultLabel.SetAppThemeColor(Label.TextColorProperty, Color.Black, Color.White);

							ResultsStackLayout.Children.Add(resultLabel);
						}

						i++;
					}
				}
				else if (scope == "Term 1: Test")
                {
					int i = 0;
					foreach(string result in term1TestResults)
                    {
						if (result != "-")
                        {
							var resultLabel = new Label { Text = $"{testResultsHeaders[i]}: {result}", Margin = new Thickness(5, 0, 0, 0) };
							resultLabel.SetAppThemeColor(Label.TextColorProperty, Color.Black, Color.White);

							ResultsStackLayout.Children.Add(resultLabel);
						}

						i++;
                    }
                }
				else if (scope == "Term 2: Test")
                {
					int i = 0;
					foreach(string result in term2TestResults)
                    {
						if (result != "-")
                        {
							var resultLabel = new Label { Text = $"{testResultsHeaders[i]}: {result}", Margin = new Thickness(5, 0, 0, 0) };
							resultLabel.SetAppThemeColor(Label.TextColorProperty, Color.Black, Color.White);

							ResultsStackLayout.Children.Add(resultLabel);
						}

						i++;
                    }
                }
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
        }
    }
}