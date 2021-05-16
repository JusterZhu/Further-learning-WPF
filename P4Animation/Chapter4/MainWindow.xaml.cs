using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chapter4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DemoDoubleAnmation();
            //DemoMatrixAnimationUsingPathDoesRotateWithTangent();

            //DemoFrom();  //只写From;     From作为起始值，Width作为它的终止值。
            //DemoTo();    //只写To;       Width作为它的起始值，To作为它的终止值。
            //DemoBy();    //只写By;       Width作为其起始值，By+Width作为它的终止值。
            //DemoFromBy();//From、By都有; From作为起始值，By+From作为它的终止值。
            //DemoFromTo();//From、To都有; From作为起始值，To作为它的终止值。
        }

        #region Double Animation

        private Storyboard myStoryboard;

        public void DemoDoubleAnmation()
        {
            //StackPanel myPanel = new StackPanel();
            //myPanel.Margin = new Thickness(10);

            Rectangle myRectangle = new Rectangle();
            myRectangle.Name = "myRectangle";
            this.RegisterName(myRectangle.Name, myRectangle);
            myRectangle.Width = 100;
            myRectangle.Height = 100;
            myRectangle.Fill = Brushes.Blue;

            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 1.0;
            myDoubleAnimation.To = 0.0;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
            myDoubleAnimation.AutoReverse = true;
            myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            AnimationClock clock = myDoubleAnimation.CreateClock();
            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetName(myDoubleAnimation, myRectangle.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.OpacityProperty));
            // Use the Loaded event to start the Storyboard.
            //myRectangle.Loaded += new RoutedEventHandler(myRectangleLoaded);
            GridRoot.Children.Add(myRectangle);
            //this.Content = myPanel;
        }

        //private void myRectangleLoaded(object sender, RoutedEventArgs e)
        //{
        //    myStoryboard.Begin(this);
        //}

        private void BtnBegin_Click(object sender, RoutedEventArgs e)
        {
            myStoryboard.Begin(this,true);
        }

        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            myStoryboard.Pause(this);
        }

        #endregion

        #region Path Animation

        public void DemoMatrixAnimationUsingPathDoesRotateWithTangent() 
        {
            this.Margin = new Thickness(20);

            // Create a NameScope for the page so that
            // we can use Storyboards.
            NameScope.SetNameScope(this, new NameScope());

            // Create a button.
            Button aButton = new Button();
            aButton.MinWidth = 100;
            aButton.Content = "A Button";

            // Create a MatrixTransform. This transform
            // will be used to move the button.
            MatrixTransform buttonMatrixTransform = new MatrixTransform();
            aButton.RenderTransform = buttonMatrixTransform;

            // Register the transform's name with the page
            // so that it can be targeted by a Storyboard.
            this.RegisterName("ButtonMatrixTransform", buttonMatrixTransform);

            // Create a Canvas to contain the button
            // and add it to the page.
            // Although this example uses a Canvas,
            // any type of panel will work.
            Canvas mainPanel = new Canvas();
            mainPanel.Width = 400;
            mainPanel.Height = 400;
            mainPanel.Children.Add(aButton);
            this.Content = mainPanel;

            // Create the animation path.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pFigure = new PathFigure();
            pFigure.StartPoint = new Point(10, 100);
            PolyBezierSegment pBezierSegment = new PolyBezierSegment();
            pBezierSegment.Points.Add(new Point(35, 0));
            pBezierSegment.Points.Add(new Point(135, 0));
            pBezierSegment.Points.Add(new Point(160, 100));
            pBezierSegment.Points.Add(new Point(180, 190));
            pBezierSegment.Points.Add(new Point(285, 200));
            pBezierSegment.Points.Add(new Point(310, 100));
            pFigure.Segments.Add(pBezierSegment);
            animationPath.Figures.Add(pFigure);

            // Freeze the PathGeometry for performance benefits.
            animationPath.Freeze();

            // Create a MatrixAnimationUsingPath to move the
            // button along the path by animating
            // its MatrixTransform.
            MatrixAnimationUsingPath matrixAnimation =
                new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = animationPath;
            matrixAnimation.Duration = TimeSpan.FromSeconds(5);
            matrixAnimation.RepeatBehavior = RepeatBehavior.Forever;

            // Set the animation's DoesRotateWithTangent property
            // to true so that rotates the rectangle in addition
            // to moving it.
            matrixAnimation.DoesRotateWithTangent = true;

            // Set the animation to target the Matrix property
            // of the MatrixTransform named "ButtonMatrixTransform".
            Storyboard.SetTargetName(matrixAnimation, "ButtonMatrixTransform");
            Storyboard.SetTargetProperty(matrixAnimation,
                new PropertyPath(MatrixTransform.MatrixProperty));

            // Create a Storyboard to contain and apply the animation.
            Storyboard pathAnimationStoryboard = new Storyboard();
            pathAnimationStoryboard.Children.Add(matrixAnimation);

            // Start the storyboard when the button is loaded.
            aButton.Loaded += delegate (object sender, RoutedEventArgs e)
            {
                // Start the storyboard.
                pathAnimationStoryboard.Begin(this);
            };
        }

        #endregion

        #region From/To/By Animation

       /*
        * 当你同时设置 From 和 To 值时，动画将从属性指定的值前进 From 到属性指定的值 To 。
        * 下面的示例将 From 的属性设置 DoubleAnimation 为50，并将其 To 属性设置为300。 
        * 因此，的将 Width Rectangle 从50到300进行动画处理。
        */
        public void DemoFromTo() 
        {
            // Demonstrates the From and To properties used together.

            // Create a NameScope for this page so that
            // Storyboards can be used.
            NameScope.SetNameScope(this, new NameScope());

            Rectangle myRectangle = new Rectangle();

            // Assign the Rectangle a name so that
            // it can be targeted by a Storyboard.
            this.RegisterName(
                "fromToAnimatedRectangle", myRectangle);
            myRectangle.Height = 10;
            myRectangle.Width = 100;
            myRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myRectangle.Fill = Brushes.Black;

            // Demonstrates the From and To properties used together.
            // Animates the rectangle's Width property from 50 to 300 over 10 seconds.
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 50;
            myDoubleAnimation.To = 300;
            myDoubleAnimation.Duration =
                new Duration(TimeSpan.FromSeconds(10));

            Storyboard.SetTargetName(myDoubleAnimation, "fromToAnimatedRectangle");
            Storyboard.SetTargetProperty(myDoubleAnimation,
                new PropertyPath(Rectangle.WidthProperty));
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);

            // Use an anonymous event handler to begin the animation
            // when the rectangle is clicked.
            myRectangle.MouseLeftButtonDown += delegate (object sender, MouseButtonEventArgs args)
            {
                myStoryboard.Begin(myRectangle);
            };
            GridRoot.Children.Add(myRectangle);
        }

        /*
         * 当只指定动画的 From 值时，动画将从属性指定的值前进到要进行 From 动画处理的属性的基值或组合动画的输出。
         * 下面的示例仅将 From 的属性设置 DoubleAnimation 为50。 由于未指定终止值，因此将 DoubleAnimation 使用 Width 属性100的基值作为其结束值。 的将 Width Rectangle 从50动画处理到属性的基数值 Width 100。
         */
        public void DemoFrom()
        {
            // Demonstrates the use of the From property.

            // Create a NameScope for this page so that
            // Storyboards can be used.
            NameScope.SetNameScope(this, new NameScope());

            Rectangle myRectangle = new Rectangle();

            // Assign the Rectangle a name so that
            // it can be targeted by a Storyboard.
            this.RegisterName(
                "fromAnimatedRectangle", myRectangle);
            myRectangle.Height = 10;
            myRectangle.Width = 100;
            myRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myRectangle.Fill = Brushes.Purple;

            // Demonstrates the From property used by itself. Animates the
            // rectangle's Width property from 50 to its base value (100)
            // over 10 seconds.
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 50;
            myDoubleAnimation.Duration =
                new Duration(TimeSpan.FromSeconds(10));

            Storyboard.SetTargetName(myDoubleAnimation, "fromAnimatedRectangle");
            Storyboard.SetTargetProperty(myDoubleAnimation,
                new PropertyPath(Rectangle.WidthProperty));
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);

            // Use an anonymous event handler to begin the animation
            // when the rectangle is clicked.
            myRectangle.MouseLeftButtonDown += delegate (object sender, MouseButtonEventArgs args)
            {
                myStoryboard.Begin(myRectangle);
            };

            GridRoot.Children.Add(myRectangle);
        }

        /*
         * 当只设置属性时 To ，动画将从已进行动画处理的属性的基值或从以前应用到同一个属性的组合动画的输出前进到由属性指定的值 To 。
         * ( "组合动画" 是指 Active Filling 以前应用到同一个属性的或动画，该属性在使用移交行为应用当前动画时仍有效 Compose 。 )
         *下面的示例仅将 To 的属性设置 DoubleAnimation 为300。 
         *由于未指定起始值，因此将 DoubleAnimation 使用该属性的基值 (100) Width 作为其起始值。 
         *的Width Rectangle 被动画处理从100到动画的目标值300。
         */
        public void DemoTo() 
        {
            // Demonstrates the use of the To property.

            // Create a NameScope for this page so that
            // Storyboards can be used.
            NameScope.SetNameScope(this, new NameScope());

            Rectangle myRectangle = new Rectangle();

            // Assign the Rectangle a name so that
            // it can be targeted by a Storyboard.
            this.RegisterName(
                "toAnimatedRectangle", myRectangle);
            myRectangle.Height = 10;
            myRectangle.Width = 100;
            myRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myRectangle.Fill = Brushes.Gray;

            // Demonstrates the To property used by itself. Animates
            // the Rectangle's Width property from its base value
            // (100) to 300 over 10 seconds.
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.To = 300;
            myDoubleAnimation.Duration =
                new Duration(TimeSpan.FromSeconds(10));

            Storyboard.SetTargetName(myDoubleAnimation, "toAnimatedRectangle");
            Storyboard.SetTargetProperty(myDoubleAnimation,
                new PropertyPath(Rectangle.WidthProperty));
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);

            // Use an anonymous event handler to begin the animation
            // when the rectangle is clicked.
            myRectangle.MouseLeftButtonDown += delegate (object sender, MouseButtonEventArgs args)
            {
                myStoryboard.Begin(myRectangle);
            };
            GridRoot.Children.Add(myRectangle);
        }

       /* 
        *当只设置动画的 By 属性时，动画将从要进行动画处理的属性的基值开始，或者从组合动画的输出到该值的总和和属性指定的值 By 。
        *下面的示例仅将 By 的属性设置 DoubleAnimation 为300。 
        *由于该示例未指定起始值，因此将 DoubleAnimation 使用属性的基值 Width 100 作为其起始值。 
        *结束值通过将 By 动画的值300添加到其起始值100：400来确定。 
        *因此，的将 Width Rectangle 从100到400进行动画处理。
        */
        public void DemoBy() 
        {
            // Demonstrates the use of the By property.

            // Create a NameScope for this page so that
            // Storyboards can be used.
            NameScope.SetNameScope(this, new NameScope());

            Rectangle myRectangle = new Rectangle();

            // Assign the Rectangle a name so that
            // it can be targeted by a Storyboard.
            this.RegisterName(
                "byAnimatedRectangle", myRectangle);
            myRectangle.Height = 10;
            myRectangle.Width = 100;
            myRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myRectangle.Fill = Brushes.RoyalBlue;

            // Demonstrates the By property used by itself.
            // Increments the Rectangle's Width property by 300 over 10 seconds.
            // As a result, the Width property is animated from its base value
            // (100) to 400 (100 + 300) over 10 seconds.
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.By = 300;
            myDoubleAnimation.Duration =
                new Duration(TimeSpan.FromSeconds(10));

            Storyboard.SetTargetName(myDoubleAnimation, "byAnimatedRectangle");
            Storyboard.SetTargetProperty(myDoubleAnimation,
                new PropertyPath(Rectangle.WidthProperty));
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);

            // Use an anonymous event handler to begin the animation
            // when the rectangle is clicked.
            myRectangle.MouseLeftButtonDown += delegate (object sender, MouseButtonEventArgs args)
            {
                myStoryboard.Begin(myRectangle);
            };
            GridRoot.Children.Add(myRectangle);
        }

        /*
         * 设置 From 动画的和 By 属性时，动画将从属性所指定的值前进 From 到由和属性的和指定的值 From By 。
         * 下面的示例将 From 的属性设置 DoubleAnimation 为50，并将其 By 属性设置为300。 
         * 结束值通过将 By 动画的值300添加到其起始值50：350来确定。
         * 因此，的将 Width Rectangle 从50到350进行动画处理。
         */
        public void DemoFromBy() 
        {
            // Demonstrates the use of the From and By properties.

            // Create a NameScope for this page so that
            // Storyboards can be used.
            NameScope.SetNameScope(this, new NameScope());

            Rectangle myRectangle = new Rectangle();

            // Assign the Rectangle a name so that
            // it can be targeted by a Storyboard.
            this.RegisterName(
                "byAnimatedRectangle", myRectangle);
            myRectangle.Height = 10;
            myRectangle.Width = 100;
            myRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myRectangle.Fill = Brushes.BlueViolet;

            // Demonstrates the From and By properties used together.
            // Increments the Rectangle's Width property by 300 over 10 seconds.
            // As a result, the Width property is animated from 50
            // to 350 (50 + 300) over 10 seconds.
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 50;
            myDoubleAnimation.By = 300;
            myDoubleAnimation.Duration =
                new Duration(TimeSpan.FromSeconds(10));

            Storyboard.SetTargetName(myDoubleAnimation, "byAnimatedRectangle");
            Storyboard.SetTargetProperty(myDoubleAnimation,
                new PropertyPath(Rectangle.WidthProperty));
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);

            // Use an anonymous event handler to begin the animation
            // when the rectangle is clicked.
            myRectangle.MouseLeftButtonDown += delegate (object sender, MouseButtonEventArgs args)
            {
                myStoryboard.Begin(myRectangle);
            };
            GridRoot.Children.Add(myRectangle);
        }

        #endregion

        #region Key-Frame Animation

        /*
         * 百分比值指定关键帧以某些百分比的动画结束 Duration 。 在 XAML 中，指定百分比作为 % 符号后的数字。 在代码中，使用 FromPercent 方法并向其传递 Double 指示百分比的。 该值必须大于或等于 0 并且小于或等于 100%。 以下示例演示一个持续时间为 10 秒钟、有四个关键帧（这些关键帧的关键时间指定为百分比）的动画。
           在前 3 秒钟内，第一个关键帧将在基值和 100 之间进行动画处理，结束时间 = 0:0:3。
           第二个关键帧在 100 和 200 之间进行动画处理。 它在第一个关键帧结束后开始（开始时间 = 3 秒），播放 5 秒钟，结束时间 = 0:0:8 (0.8 * 10 = 8)。
           第三个关键帧在 200 和 500 之间进行动画处理。 它在第二个关键帧结束时开始（开始时间 = 8 秒），播放 1 秒钟，结束时间 = 0:0:9 (0.9 * 10 = 9)。
           第四个关键帧在 500 和 600 之间进行动画处理。 它在第三个关键帧结束时开始（开始时间 = 9 秒），播放 1 秒钟，结束时间 = 0:0:10 (1 * 10 = 10)。
         */

        //<!-- Identical animation behavior to the previous rectangle but using percentage values for KeyTimes rather then TimeSpan. -->
        //<Rectangle Height = "50" Width= "50" Fill= "Purple" >
        //  < Rectangle.RenderTransform >
        //    < TranslateTransform x:Name= "TranslateTransform02" X= "10" Y= "110" />
        //  </ Rectangle.RenderTransform >
        //  < Rectangle.Triggers >
        //    < EventTrigger RoutedEvent= "Rectangle.Loaded" >
        //      < BeginStoryboard >
        //        < Storyboard >
        //          < DoubleAnimationUsingKeyFrames
        //            Storyboard.TargetName= "TranslateTransform02"
        //            Storyboard.TargetProperty= "X"
        //            Duration= "0:0:10"
        //            RepeatBehavior= "Forever" >

        //            < !--KeyTime properties are expressed as Percentages. -->
        //            <LinearDoubleKeyFrame Value = "100" KeyTime= "30%" />
        //            < LinearDoubleKeyFrame Value= "200" KeyTime= "80%" />
        //            < LinearDoubleKeyFrame Value= "500" KeyTime= "90%" />
        //            < LinearDoubleKeyFrame Value= "600" KeyTime= "100%" />
        //          </ DoubleAnimationUsingKeyFrames >
        //        </ Storyboard >
        //      </ BeginStoryboard >
        //    </ EventTrigger >
        //  </ Rectangle.Triggers >
        //</ Rectangle >

        #endregion
    }
}
