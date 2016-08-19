using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace WorkingWithBehaviors
{
    public static class NumericValidationBehavior
    {
        public static readonly BindableProperty AttachBehaviorProperty =
            BindableProperty.CreateAttached("AttachBehavior", typeof(bool), typeof(NumericValidationBehavior), false, propertyChanged: OnAttachBehaviorChanged);

        public static bool GetAttachBehavior(BindableObject view)
        {
            return (bool)view.GetValue(AttachBehaviorProperty);
        }

        public static void SetAttachBehavior(BindableObject view, bool value)
        {
            view.SetValue(AttachBehaviorProperty, value);
        }

        static void OnAttachBehaviorChanged(BindableObject view, object oldValue, object newValue)
        {
            var entry = view as Entry;
            if (entry == null)
            {
                return;
            }

            bool attachBehavior = (bool)newValue;
            if (attachBehavior)
            {
                entry.TextChanged += OnEntryTextChanged;
            }
            else
            {
                entry.TextChanged -= OnEntryTextChanged;
            }
        }

        static void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            double result;
            bool isValid = double.TryParse(args.NewTextValue, out result);
            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }
    }

    public static class CEPValidationBehavior
    {
        public static readonly BindableProperty AttachBehaviorProperty =
            BindableProperty.CreateAttached("AttachBehavior", typeof(bool), typeof(CEPValidationBehavior), false, propertyChanged: OnAttachBehaviorChanged);

        public static bool GetAttachBehavior(BindableObject view)
        {
            return (bool)view.GetValue(AttachBehaviorProperty);
        }

        public static void SetAttachBehavior(BindableObject view, bool value)
        {
            view.SetValue(AttachBehaviorProperty, value);
        }

        static void OnAttachBehaviorChanged(BindableObject view, object oldValue, object newValue)
        {
            var entry = view as Entry;
            if (entry == null)
            {
                return;
            }

            bool attachBehavior = (bool)newValue;
            if (attachBehavior)
            {
                entry.TextChanged += OnEntryTextChanged;
            }
            else
            {
                entry.TextChanged -= OnEntryTextChanged;
            }
        }

        static void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            bool isValid = false;
            string result = args.NewTextValue;
            //result = result.Replace("[^A-Za-z0-9_]", "");
            if (result.Length > 5 && !result.Contains("-"))
            {
                ((Entry)sender).Text = String.Format(
                                        "{0}-{1}",
                                        result.Substring(0, 5),
                                        result.Substring(5));
            }


            if (result.Length == 9)
            {
                Regex regex = new Regex(@"^\d{5}\-?\d{3}$");

                Match match = regex.Match(result);

                if (match.Success)
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }

            }
            else
            {
                isValid = false;
            }


            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }
    }

    public static class CPFValidationBehavior
    {
        public static readonly BindableProperty AttachBehaviorProperty =
            BindableProperty.CreateAttached("AttachBehavior", typeof(bool), typeof(CPFValidationBehavior), false, propertyChanged: OnAttachBehaviorChanged);

        public static bool GetAttachBehavior(BindableObject view)
        {
            return (bool)view.GetValue(AttachBehaviorProperty);
        }

        public static void SetAttachBehavior(BindableObject view, bool value)
        {
            view.SetValue(AttachBehaviorProperty, value);
        }

        static void OnAttachBehaviorChanged(BindableObject view, object oldValue, object newValue)
        {
            var entry = view as Entry;
            if (entry == null)
            {
                return;
            }

            bool attachBehavior = (bool)newValue;
            if (attachBehavior)
            {
                entry.TextChanged += OnEntryTextChanged;
            }
            else
            {
                entry.TextChanged -= OnEntryTextChanged;
            }
        }

        static void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            bool isValid = false;
            string result = args.NewTextValue.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", ""); ;

            //Para saber se estamos apagando ou incluindo 

            if (!string.IsNullOrEmpty(args.OldTextValue) && !string.IsNullOrEmpty(args.NewTextValue))
            {

                if (args.NewTextValue.Length > args.OldTextValue.Length)
                {
                    if (result.Length > 3 && result.Length < 6)
                    {
                        ((Entry)sender).Text = String.Format(
                                                "{0}.{1}",
                                                result.Substring(0, 3),
                                                result.Substring(3));
                    }
                    else if (result.Length > 6 && result.Length < 9)
                    {
                        result = result.Replace(".", "");
                        ((Entry)sender).Text = String.Format(
                                                "{0}.{1}.{2}",
                                                result.Substring(0, 3),
                                                result.Substring(3, 3),
                                                result.Substring(6));
                    }
                    else if (result.Length > 9 && result.Length < 11)
                    {
                        result = result.Replace(".", "");
                        ((Entry)sender).Text = String.Format(
                                                "{0}.{1}.{2}-{3}",
                                                result.Substring(0, 3),
                                                result.Substring(3, 3),
                                                result.Substring(6, 3),
                                                result.Substring(9));
                    }
                    else if (result.Length == 11)
                    {
                        Regex regex = new Regex(@"^\d{3}\.?\d{3}\.?\d{3}\-?\d{2}$");

                        Match match = regex.Match(result);

                        if (match.Success)
                        {
                            var resultlimpo = result.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");
                            // Caso coloque todos os numeros iguais
                            switch (resultlimpo)
                            {
                                case "00000000000":
                                    isValid = false;
                                    break;
                                case "11111111111":
                                    isValid = false;
                                    break;
                                case "2222222222":
                                    isValid = false;
                                    break;
                                case "33333333333":
                                    isValid = false;
                                    break;
                                case "44444444444":
                                    isValid = false;
                                    break;
                                case "55555555555":
                                    isValid = false;
                                    break;
                                case "66666666666":
                                    isValid = false;
                                    break;
                                case "77777777777":
                                    isValid = false;
                                    break;
                                case "88888888888":
                                    isValid = false;
                                    break;
                                case "99999999999":
                                    isValid = false;
                                    break;
                                default:
                                    int v1 = 0, v2 = 0, dig = -1;

                                    for (int i = 0; i < 9; i++)
                                    {
                                        dig = resultlimpo[i] - 48; // ASCII de '0' a 48
                                        v1 += (10 - i) * dig;
                                        v2 += (11 - i) * dig;
                                    }

                                    // primeiro digito verificador
                                    if ((v1 %= 11) < 2)
                                    {
                                        v1 = 0;
                                    }
                                    else
                                    {
                                        v1 = 11 - v1;
                                    }

                                    // primeiro digito verificador
                                    v2 += 2 * v1;
                                    if ((v2 %= 11) < 2)
                                    {
                                        v2 = 0;
                                    }
                                    else
                                    {
                                        v2 = 11 - v2;
                                    }
                                    isValid = (v1 == (resultlimpo[9] - 48) && v2 == (resultlimpo[10] - 48));
                                    break;
                            }
                        }
                        else
                        {
                            isValid = false;
                        }

                    }
                    else
                    {
                        isValid = false;
                    }

                ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
                }
                else
                {

                    string resultlimpo = result;
                    resultlimpo = resultlimpo.Replace(".", "").Replace("-", "");

                    ((Entry)sender).Text = resultlimpo;
                    ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
                }
            }
        }
    }

    public static class CNPJValidationBehavior
    {
        public static readonly BindableProperty AttachBehaviorProperty =
            BindableProperty.CreateAttached("AttachBehavior", typeof(bool), typeof(CNPJValidationBehavior), false, propertyChanged: OnAttachBehaviorChanged);

        public static bool GetAttachBehavior(BindableObject view)
        {
            return (bool)view.GetValue(AttachBehaviorProperty);
        }

        public static void SetAttachBehavior(BindableObject view, bool value)
        {
            view.SetValue(AttachBehaviorProperty, value);
        }

        static void OnAttachBehaviorChanged(BindableObject view, object oldValue, object newValue)
        {
            var entry = view as Entry;
            if (entry == null)
            {
                return;
            }

            bool attachBehavior = (bool)newValue;
            if (attachBehavior)
            {
                entry.TextChanged += OnEntryTextChanged;
            }
            else
            {
                entry.TextChanged -= OnEntryTextChanged;
            }
        }

        static void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            string result = args.NewTextValue.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");
            bool isValid = false;

            if (!string.IsNullOrEmpty(args.OldTextValue) && !string.IsNullOrEmpty(args.NewTextValue))
            {
                if (args.NewTextValue.Length > args.OldTextValue.Length)
                {
                    if (result.Length > 2 && result.Length < 5)
                    {
                        ((Entry)sender).Text = String.Format(
                                               "{0}.{1}",
                                               result.Substring(0, 2),
                                               result.Substring(2));
                    }
                    else if (result.Length > 5 && result.Length < 8)
                    {
                        result = result.Replace(".", "");
                        ((Entry)sender).Text = String.Format(
                                                "{0}.{1}.{2}",
                                                result.Substring(0, 2),
                                                result.Substring(2, 3),
                                                result.Substring(5));

                    }
                    else if (result.Length > 8 && result.Length < 12)
                    {
                        result = result.Replace(".", "").Replace("/", "");
                        ((Entry)sender).Text = String.Format(
                                                "{0}.{1}.{2}/{3}",
                                                result.Substring(0, 2),
                                                result.Substring(2, 3),
                                                result.Substring(5, 3),
                                                result.Substring(8));

                    }
                    else if (result.Length > 12 && result.Length < 14)
                    {
                        result = result.Replace(".", "").Replace("/", "").Replace("-", "");
                        ((Entry)sender).Text = String.Format(
                                                "{0}.{1}.{2}/{3}-{4}",
                                                result.Substring(0, 2),
                                                result.Substring(2, 3),
                                                result.Substring(5, 3),
                                                result.Substring(8, 4),
                                                result.Substring(12));

                    }
                    else if (result.Length == 14)
                    {
                        Regex regex = new Regex(@"^\d{2}.?\d{3}.?\d{3}/?\d{4}-?\d{2}$");

                        Match match = regex.Match(result);

                        if (match.Success)
                        {
                            // Caso coloque todos os numeros iguais
                            switch (result)
                            {
                                case "00000000000000":
                                    isValid = false;
                                    break;
                                case "11111111111111":
                                    isValid = false;
                                    break;
                                case "2222222222222":
                                    isValid = false;
                                    break;
                                case "33333333333333":
                                    isValid = false;
                                    break;
                                case "44444444444444":
                                    isValid = false;
                                    break;
                                case "55555555555555":
                                    isValid = false;
                                    break;
                                case "66666666666666":
                                    isValid = false;
                                    break;
                                case "77777777777777":
                                    isValid = false;
                                    break;
                                case "88888888888888":
                                    isValid = false;
                                    break;
                                case "99999999999999":
                                    isValid = false;
                                    break;
                                default:
                                    int v1 = 0, v2 = 0, dig = -1, mask1 = 5, mask2 = 6;

                                    for (int i = 0; i < 12; i++)
                                    {
                                        dig = result[i] - 48; // ASCII de '0' a 48
                                        v1 += (mask1--) * dig;
                                        v2 += (mask2--) * dig;
                                        if (mask1 == 1)
                                        {
                                            mask1 = 9;
                                        }
                                        if (mask2 == 1)
                                        {
                                            mask2 = 9;
                                        }
                                    }

                                    // primeiro digito verificador
                                    if ((v1 %= 11) < 2)
                                    {
                                        v1 = 0;
                                    }
                                    else
                                    {
                                        v1 = 11 - v1;
                                    }

                                    // primeiro digito verificador
                                    v2 += 2 * v1;
                                    if ((v2 %= 11) < 2)
                                    {
                                        v2 = 0;
                                    }
                                    else
                                    {
                                        v2 = 11 - v2;
                                    }
                                    isValid = (v1 == (result[12] - 48) && v2 == (result[13] - 48));
                                    break;
                            }
                        }
                        else
                        {
                            isValid = false;
                        }
                    }

                }
            }

            else
            {
                isValid = false;
            }

            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }
    }
}

