using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using System.ComponentModel;

namespace CYRTextViewKit
{
    // @interface CYRLayoutManager : NSLayoutManager
    [BaseType(typeof(NSLayoutManager))]
    interface CYRLayoutManager
    {
        // @property (nonatomic, strong) UIFont * lineNumberFont;
        [Export("lineNumberFont", ArgumentSemantic.Strong)]
        UIFont LineNumberFont { get; set; }

        // @property (nonatomic, strong) UIColor * lineNumberColor;
        [Export("lineNumberColor", ArgumentSemantic.Strong)]
        UIColor LineNumberColor { get; set; }

        // @property (nonatomic, strong) UIColor * selectedLineNumberColor;
        [Export("selectedLineNumberColor", ArgumentSemantic.Strong)]
        UIColor SelectedLineNumberColor { get; set; }

        // @property (readonly, nonatomic) CGFloat gutterWidth;
        [Export("gutterWidth")]
        nfloat GutterWidth { get; }

        // @property (assign, nonatomic) NSRange selectedRange;
        [Export("selectedRange", ArgumentSemantic.Assign)]
        NSRange SelectedRange { get; set; }

        // -(CGRect)paragraphRectForRange:(NSRange)range;
        [Export("paragraphRectForRange:")]
        CGRect ParagraphRectForRange(NSRange range);
    }

    // @interface CYRTextStorage : NSTextStorage
    [BaseType(typeof(NSTextStorage))]
    interface CYRTextStorage
    {
        // @property (nonatomic, strong) NSArray<CYRToken *> * tokens;
        [Export("tokens", ArgumentSemantic.Strong)]
        CYRToken[] Tokens { get; set; }

        // @property (nonatomic, strong) UIFont * defaultFont;
        [Export("defaultFont", ArgumentSemantic.Strong)]
        UIFont DefaultFont { get; set; }

        // @property (nonatomic, strong) UIColor * defaultTextColor;
        [Export("defaultTextColor", ArgumentSemantic.Strong)]
        UIColor DefaultTextColor { get; set; }

        // -(void)update;
        [Export("update")]
        void Update();
    }

    // @interface CYRToken : NSObject
    [BaseType(typeof(NSObject))]
    interface CYRToken
    {
        // @property (nonatomic, strong) NSString * _Nullable name;
        [NullAllowed, Export("name", ArgumentSemantic.Strong)]
        string Name { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable expression;
        [NullAllowed, Export("expression", ArgumentSemantic.Strong)]
        string Expression { get; set; }

        // @property (nonatomic, strong) NSDictionary<NSString *,id> * _Nullable attributes;
        [NullAllowed, Export("attributes", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSObject> Attributes { get; set; }

        [Export("initWithName:expression:foregroundColor:font:backgroundColor:")]
        IntPtr Constructor(string name, string expression, UIColor foregroundColor, UIFont font, UIColor backgroundColor);

        [Export("initWithName:expression:foregroundColor:font:")]
        IntPtr Constructor(string name, string expression, UIColor foregroundColor, UIFont font);

        [Export("initWithName:expression:foregroundColor:")]
        IntPtr Constructor(string name, string expression, UIColor foregroundColor);
    }

    // @interface CYRTextView : UITextView
    [BaseType(typeof(UITextView))]
    interface CYRTextView
    {
        // @property (nonatomic, strong) NSArray<CYRToken *> * tokens;
        [Export("tokens", ArgumentSemantic.Strong)]
        CYRToken[] Tokens { get; set; }

        // @property (nonatomic, strong) UIPanGestureRecognizer * singleFingerPanRecognizer;
        [Export("singleFingerPanRecognizer", ArgumentSemantic.Strong)]
        UIPanGestureRecognizer SingleFingerPanRecognizer { get; set; }

        // @property (nonatomic, strong) UIPanGestureRecognizer * doubleFingerPanRecognizer;
        [Export("doubleFingerPanRecognizer", ArgumentSemantic.Strong)]
        UIPanGestureRecognizer DoubleFingerPanRecognizer { get; set; }

        [Export("syntaxTextStorage", ArgumentSemantic.Strong)]
        CYRTextStorage SyntaxTextStorage { get; set; }

        // @property UIColor * gutterBackgroundColor;
        [Export("gutterBackgroundColor", ArgumentSemantic.Assign), Browsable(true)]
        UIColor GutterBackgroundColor { get; set; }

        // @property UIColor * gutterLineColor;
        [Export("gutterLineColor", ArgumentSemantic.Assign), Browsable(true)]
        UIColor GutterLineColor { get; set; }

        // @property (assign, nonatomic) BOOL lineCursorEnabled;
        [Export("lineCursorEnabled"), Browsable(true)]
        bool LineCursorEnabled { get; set; }

        [Export("initWithFrame:")]
        IntPtr Constructor(CGRect frame);
    }

}
