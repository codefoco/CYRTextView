using System;
using System.ComponentModel;
using CoreGraphics;
using CYRTextViewKit;
using Foundation;
using UIKit;

namespace CYRTextViewExample
{
    [Register("QEDView")]
    public class QEDView : CYRTextView
    {
        UIFont boldFont;
        UIFont italicFont;

        public QEDView(IntPtr handle) : base (handle)
        {
        }

        public QEDView()
        {

        }

        [Export("awakeAfterUsingCoder:")]
        public NSObject AwakeAfterUsingCoder (NSCoder aDecoder)
        {
            return new QEDView(Frame);
        }


        public QEDView(CGRect rect):base(rect)
        {
            Initilize();
        }

        private void Initilize()
        {
            boldFont = UIFont.FromName("Menlo-Bold", 14.0f);
            italicFont = UIFont.FromName("Menlo-Italic", 14.0f);

            Tokens = new[] {
            new CYRToken("string", "\".*?(\"|$)", UIColor.FromRGB (24, 110, 109)),
            new CYRToken("hex", "\\b0x[0-9 a-f]+\\b", UIColor.FromRGB (0, 0, 255)),
            new CYRToken("float", "\\b\\d+\\.?\\d+e[\\+\\-]?\\d+\\b|\\b\\d+\\.\\d+\\b", UIColor.FromRGB (10, 136, 91)),
            new CYRToken("int", "\\b\\d+\\b", UIColor.FromRGB (0, 0, 255)),
            new CYRToken("operator", "[/\\*,\\;:=<>\\+\\-\\^!·≤≥|]", UIColor.FromRGB (245, 0, 110)),
            new CYRToken("round_brackets", "[\\(\\)]", UIColor.FromRGB (161, 75, 0)),
            new CYRToken("square_brackets", "[\\[\\]]", UIColor.FromRGB (105, 0, 0), boldFont),
            new CYRToken("reserved_words", "(abs|acos|acosh|asin|asinh|atan|atanh|atomicweight|ceil|complex|cos|cosh|crandom|deriv|erf|erfc|exp|eye|floor|frac|gamma|gaussel|getconst|imag|inf|integ|integhq|inv|ln|log10|log2|machineprecision|max|maximize|min|minimize|molecularweight|ncum|ones|pi|plot|random|real|round|sgn|sin|sqr|sinh|sqrt|tan|tanh|transpose|trunc|var|zeros)",
                        UIColor.FromRGB (104, 0, 111), boldFont),
            new CYRToken("chart_parameters", "(chartheight|charttitle|chartwidth|color|seriesname|showlegend|showxmajorgrid|showxminorgrid|showymajorgrid|showyminorgrid|transparency|thickness|xautoscale|xaxisrange|xlabel|xlogscale|xrange|yautoscale|yaxisrange|ylabel|ylogscale|yrange)",
            UIColor.FromRGB (11, 81, 195)),
            new CYRToken("comment", "//.*", UIColor.FromRGB (31, 131, 0), italicFont)
            };
        }
    }
}
