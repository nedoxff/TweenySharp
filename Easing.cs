using System;
using System.Collections.Generic;

namespace TweenySharp
{
    public class Easing
    {
        public static HashSet<Type> SignedIntegralTypes = new() 
        {
            typeof(int), typeof(short), typeof(char),
            typeof(long), typeof(sbyte)
        };
        public static HashSet<Type> UnsignedIntegralTypes = new() 
        {
            typeof(uint), typeof(ushort),
            typeof(ulong), typeof(byte)
        };
        public static HashSet<Type> RealTypes = new() 
        {
            typeof(float), typeof(double),
            typeof(decimal)
        };

        public static bool IsNumeric<T>() => SignedIntegralTypes.Contains(typeof(T)) ||
                                                    UnsignedIntegralTypes.Contains(typeof(T)) ||
                                                    RealTypes.Contains(typeof(T));

        public static bool IsSigned<T>() => SignedIntegralTypes.Contains(typeof(T));
        public static bool IsUnsigned<T>() => UnsignedIntegralTypes.Contains(typeof(T));
        public enum EaseType
        {
            Default,
            Linear,
            Stepped,
            QuadraticIn,
            QuadraticOut,
            QuadraticInOut,
            CubicIn,
            CubicOut,
            CubicInOut,
            QuarticIn,
            QuarticOut,
            QuarticInOut,
            QuinticIn,
            QuinticOut,
            QuinticInOut,
            SinusoidalIn,
            SinusoidalOut,
            SinusoidalInOut,
            ExponentialIn,
            ExponentialOut,
            ExponentialInOut,
            CircularIn,
            CircularOut,
            CircularInOut,
            BounceIn,
            BounceOut,
            BounceInOut,
            ElasticIn,
            ElasticOut,
            ElasticInOut,
            BackIn,
            BackOut,
            BackInOut
        }

        public interface IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end);
        }
        
        public class Default: IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                return MathF.Round(end - start) * position + start;
            }
        }

        public class Linear : IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                return (end - start) * position + start;
            }
        }
        
        public class Stepped: IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                return start;
            }
        }

        public class QuadraticIn: IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                return (end - start) * MathF.Pow(position, 2) + start;
            }
        }
        
        public class QuadraticOut: IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                return -(end - start) * position * (position - 2) + start;
            }
        }

        public class QuadraticInOut : IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                position *= 2;
                if (position < 1)
                {
                    return (end - start) / 2 * MathF.Pow(position, 2) + start;
                }

                --position;
                return -(end - start) / 2 * (position * (position - 2) - 1) + start;
            }
        }
        
        public class CubicIn: IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                return (end - start) * MathF.Pow(position, 3) + start;
            }
        }

        public class CubicOut : IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                return (end - start) * (MathF.Pow(position, 3) + 1) + start;
            }
        }
        
        public class CubicInOut: IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                position *= 2;
                if (position < 1)
                {
                    return (end - start) / 2 * MathF.Pow(position, 3) + start;
                }

                position -= 2;
                return (end - start) / 2 * (MathF.Pow(position, 3) + 2) + start;
            }
        }
        
        public class QuarticIn: IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                return (end - start) * MathF.Pow(position, 4) + start;
            }
        }

        public class QuarticOut : IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                return (end - start) * (MathF.Pow(position, 4) - 1) + start;
            }
        }
        
        public class QuarticInOut: IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                position *= 2;
                if (position < 1)
                {
                    return (end - start) / 2 * MathF.Pow(position, 4) + start;
                }

                position -= 2;
                return (end - start) / 2 * (MathF.Pow(position, 4) - 2) + start;
            }
        }
        
        public class QuinticIn: IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                return (end - start) * MathF.Pow(position, 5) + start;
            }
        }

        public class QuinticOut : IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                return (end - start) * (MathF.Pow(position, 5) + 1) + start;
            }
        }

        public class QuinticInOut : IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                position *= 2;
                if (position < 1)
                {
                    return (end - start) / 2 * MathF.Pow(position, 5) + start;
                }

                position -= 2;
                return (end - start) / 2 * (MathF.Pow(position, 5) + 2) + start;
            }
        }

        public class SinusoidalIn : IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                return -(end - start) * MathF.Cos(position * MathF.PI / 2) + (end - start) + start;
            }
        }

        public class SinusoidalOut : IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                return (end - start) * MathF.Sin(position * MathF.PI / 2) + start;
            }
        }

        public class SinusoidalInOut : IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                return -(end - start) / 2 * (MathF.Cos(position * MathF.PI) - 1) + start;
            }
        }

        public class ExponentialIn : IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                return (end - start) * MathF.Pow(2, 10 * (position - 1)) + start;
            }
        }
        
        public class ExponentialOut: IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                return (end - start) * (-MathF.Pow(2, -10 * position) + 1) + start;
            }
        }

        public class ExponentialInOut : IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                position *= 2;
                if (position < 1)
                {
                    return (end - start) / 2 * MathF.Pow(2, 10 * (position - 1)) + start;
                }

                --position;
                return (end - start) / 2 * (-MathF.Pow(2, -10 * position) + 2) + start;
            }
        }
        
        public class CircularIn: IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                return -(end - start) * (MathF.Sqrt((float) (1 - Math.Pow(position, 2))) - 1) + start;
            }
        }
        
        public class CircularOut: IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                return (end - start) * (MathF.Sqrt((float) (1 - Math.Pow(position, 2)))) + start;
            }
        }
        
        public class CircularInOut: IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                position *= 2;
                if (position < 1)
                {
                    return -(end - start) / 2 * (MathF.Sqrt(1 - MathF.Pow(position, 2)) - 1) + start;
                }

                position -= 2;
                return (end - start) / 2 * (MathF.Sqrt(1 - MathF.Pow(position, 2)) + 1) + start;
            }
        }

        public class BounceIn : IEase
        {
            private readonly BounceOut _bounceOut = new();
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                return end - start - _bounceOut.Run(1 - position, 0, end) + start;
            }
        }
        
        public class BounceOut: IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                var duration = end - start;
                switch (position)
                {
                    case < 1 / 2.75f:
                        return duration * (7.5625f * MathF.Pow(position, 2)) + start;
                    case < 2.0f / 2.75f:
                    {
                        var postFix = position -= 1.5f / 2.75f;
                        return duration * (7.5625f * postFix * position + .75f) + start;
                    }
                    case < 2.5f / 2.75f:
                    {
                        var postFix = position -= 2.25f / 2.75f;
                        return duration * (7.5625f * postFix * position + .9375f) + start;
                    }
                    default:
                    {
                        var postFix = position -= 2.625f / 2.75f;
                        return duration * (7.5625f * postFix * position + .984375f) + start;
                    }
                }
            }
        }
        
        public class BounceInOut: IEase
        {
            private readonly BounceOut _bounceOut = new();
            private readonly BounceIn _bounceIn = new();
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                if (position < 0.5f) return _bounceIn.Run(position * 2, 0, end) * .5f + start;
                return _bounceOut.Run(position * 2 - 1, 0, end) * .5f + (end - start) * .5f + start;
            }
        }
        
        public class ElasticIn: IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                switch (position)
                {
                    case <= 0.00001f:
                        return start;
                    case >= 0.999f:
                        return end;
                    default:
                        //i do not know what these variable names mean,
                        //this is copied straight from tweeny's source code.
                        const float p = .3f;
                        var a = end - start;
                        const float s = p / 4;
                        float postFix = a * MathF.Pow(2, 10 * (position -= 1));
                        return -(postFix * MathF.Sin((position - s) * (2 * MathF.PI)) / p) + start;
                }
            }
        }

        public class ElasticOut : IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                switch (position)
                {
                    case <= 0.00001f:
                        return start;
                    case >= 0.999f:
                        return end;
                    default:
                        //i do not know what these variable names mean,
                        //this is copied straight from tweeny's source code.
                        const float p = .3f;
                        var a = end - start;
                        const float s = p / 4;
                        return -(a * MathF.Pow(2, -10 * position) * MathF.Sin((position - s) * (2 * MathF.PI)) / p) + end;
                }
            }
        }
        
        public class ElasticInOut: IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                switch (position)
                {
                    case <= 0.00001f:
                        return start;
                    case >= 0.999f:
                        return end;
                    default:
                        position *= 2;
                        //i do not know what these variable names mean,
                        //this is copied straight from tweeny's source code.
                        const float p = .3f * 1.5f;
                        var a = end - start;
                        const float s = p / 4;

                        dynamic postFix;
                        if (position < 1)
                        {
                            postFix = a * MathF.Pow(2, 10 * (position -= 1));
                            return -.5f * (postFix * MathF.Sin((position - s) * (2 * MathF.PI)) / p) + start;
                        }

                        postFix = a * MathF.Pow(2, -10 * (position -= 1));
                        return postFix * MathF.Sin((position - s) * (2 * MathF.PI) / p) * .5f + end;
                }
            }
        }
        
        public class BackIn: IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                const float s = 1.70158f;
                return (end - start) * MathF.Pow(position, 2) * ((s + 1) * position - s) + start;
            }
        }
        
        public class BackOut: IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                const float s = 1.70158f;
                position--;
                return (end - start) * (MathF.Pow(position, 2) * ((s + 1) * position + s) + 1) + start;
            }
        }
        
        public class BackInOut: IEase
        {
            public dynamic Run(float position, dynamic start, dynamic end)
            {
                //DONT ASK
                const float s = 1.70158f * 1.525f;
                var t = position;
                var c = end - start;
                if ((t /= .5f) < 1) return c / 2 * (MathF.Pow(t, 2) * ((s + 1) * t - s) + start);
                var postFix = t -= 2;
                return c / 2 * (postFix * t * ((s + 1) * t + s) + 2) + start;
            }
        }
    }
}
