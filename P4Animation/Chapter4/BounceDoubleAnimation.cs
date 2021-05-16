using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace Chapter4
{
    public enum EdgeBehaviorEnum 
    {
        EaseIn,
        EaseOut,
        EaseInOut
    }

    public class BounceDoubleAnimation : DoubleAnimation
    {
        public static readonly DependencyProperty EdgeBehaviorProperty =
       DependencyProperty.Register("EdgeBehavior", typeof(EdgeBehaviorEnum), typeof(BounceDoubleAnimation),
           new PropertyMetadata(EdgeBehaviorEnum.EaseIn));

        public EdgeBehaviorEnum EdgeBehavior
        {
            get { return (EdgeBehaviorEnum)GetValue(EdgeBehaviorProperty); }
            set { SetValue(EdgeBehaviorProperty, value); }
        }

        public static readonly DependencyProperty BouncinessProperty =
      DependencyProperty.Register("Bounciness", typeof(double), typeof(BounceDoubleAnimation),
          new PropertyMetadata(0.0));

        /// <summary>
        /// 重复弹跳次数
        /// </summary>
        public double Bounciness
        {
            get { return (double)GetValue(BouncinessProperty); }
            set { SetValue(BouncinessProperty, value); }
        }

        public static readonly DependencyProperty BouncesProperty =
       DependencyProperty.Register("Bounces", typeof(int), typeof(BounceDoubleAnimation),
           new PropertyMetadata(0));

        /// <summary>
        /// 弹跳次数
        /// </summary>
        public int Bounces
        {
            get { return (int)GetValue(BouncesProperty); }
            set { SetValue(BouncesProperty, value); }
        }

        /// <summary>
        ///  GetCurrentValueCore 方法返回动画的当前值。 
        ///  它采用三个参数：建议的起始值、建议的结束值和 AnimationClock ，用于确定动画的进度。
        /// </summary>
        /// <param name="defaultOriginValue">建议的起始值</param>
        /// <param name="defaultDestinationValue">建议的结束值和</param>
        /// <param name="clock">AnimationClock</param>
        /// <returns></returns>
        protected override double GetCurrentValueCore(double defaultOriginValue,double defaultDestinationValue,AnimationClock clock)
        {
            double returnValue;
            var start = From ?? defaultOriginValue;
            var delta = To - start ?? defaultOriginValue - start;

            switch (EdgeBehavior)
            {
                case EdgeBehaviorEnum.EaseIn:
                    returnValue = EaseIn(clock.CurrentProgress.Value, start, delta, Bounciness, Bounces);
                    break;
                case EdgeBehaviorEnum.EaseOut:
                    returnValue = EaseOut(clock.CurrentProgress.Value, start, delta, Bounciness, Bounces);
                    break;
                default:
                    returnValue = EaseInOut(clock.CurrentProgress.Value, start, delta, Bounciness, Bounces);
                    break;
            }
            return returnValue;
        }

        /// <summary>
        /// 如果该类不使用依赖属性存储其数据，或者它在创建后需要额外初始化，则可能需要重写其他方法；
        /// </summary>
        /// <returns></returns>
        protected override Freezable CreateInstanceCore() => new BounceDoubleAnimation();

        private static double EaseOut(double timeFraction, double start, double delta, double bounciness, int bounces)
        {
            // math magic: The cosine gives us the right wave, the timeFraction is the frequency of the wave, 
            // the absolute value keeps every value positive (so it "bounces" off the midpoint of the cosine 
            // wave, and the amplitude (the exponent) makes the sine wave get smaller and smaller at the end.
            var returnValue = Math.Abs(Math.Pow((1 - timeFraction), bounciness)
                                       * Math.Cos(2 * Math.PI * timeFraction * bounces));
            returnValue = delta - (returnValue * delta);
            returnValue += start;
            return returnValue;
        }

        private static double EaseIn(double timeFraction, double start, double delta, double bounciness, int bounces)
        {
            // math magic: The cosine gives us the right wave, the timeFraction is the amplitude of the wave, 
            // the absolute value keeps every value positive (so it "bounces" off the midpoint of the cosine 
            // wave, and the amplitude (the exponent) makes the sine wave get bigger and bigger towards the end.
            var returnValue = Math.Abs(Math.Pow((timeFraction), bounciness)
                                       * Math.Cos(2 * Math.PI * timeFraction * bounces));
            returnValue = returnValue * delta;
            returnValue += start;
            return returnValue;
        }

        private static double EaseInOut(double timeFraction, double start, double delta, double bounciness, int bounces)
        {
            double returnValue;
            // we cut each effect in half by multiplying the time fraction by two and halving the distance.
            if (timeFraction <= 0.5)
            {
                returnValue = EaseIn(timeFraction * 2, start, delta / 2, bounciness, bounces);
            }
            else
            {
                returnValue = EaseOut((timeFraction - 0.5) * 2, start, delta / 2, bounciness, bounces);
                returnValue += delta / 2;
            }
            return returnValue;
        }
    }
}
