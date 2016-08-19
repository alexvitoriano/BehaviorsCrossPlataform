using Xamarin.Forms;

namespace WorkingWithBehaviors
{
	public class NumericValidationPageCS : ContentPage
	{
		public NumericValidationPageCS ()
		{
			Title = "Numeric";
			Icon = "csharp.png";

			var entry = new Entry { Placeholder = "Enter a System.Double" };
			NumericValidationBehavior.SetAttachBehavior (entry, true);

            var entry2 = new Entry { Placeholder = "Enter a System.INT" };
            CEPValidationBehavior.SetAttachBehavior(entry2, true);

            Content = new StackLayout {
				Padding = new Thickness (0, 20, 0, 0),
				Children = {
					new Label {
						Text = "Red when the number isn't valid",
						FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label))
					},
					entry,
                    entry2
				}
			};
		}
	}
}
