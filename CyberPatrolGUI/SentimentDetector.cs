using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberPatrolGUI
{
    internal class SentimentDetector
  
        {
            public static string Detect(string input)
            {
                if (input.Contains("worried") || 
                    input.Contains("scared") ||
                    input.Contains("nervous") || 
                    input.Contains("afraid"))
                    return "worried";

                if (input.Contains("curious") ||
                    input.Contains("interested") ||
                    input.Contains("want to know") ||
                    input.Contains("wondering"))
                    return "curious";

                if (input.Contains("frustrated") ||
                    input.Contains("annoyed") ||
                    input.Contains("angry") || 
                    input.Contains("confused"))
                    return "frustrated";

                if (input.Contains("happy") || 
                    input.Contains("great") ||
                    input.Contains("thanks") ||
                    input.Contains("thank you"))
                    return "positive";

                return "neutral";
            }

            public static string GetSentimentPrefix(string sentiment)
            {
                switch (sentiment)
                {
                    case "worried":
                        return "It's completely understandable to feel that way. " +
                               "You're not alone — many people feel the same. " +
                               "Let me help put your mind at ease.\n\n";
                    case "curious":
                        return "Great curiosity! That's exactly the right mindset " +
                               "for staying safe online. Here's what you need to know:\n\n";
                    case "frustrated":
                        return "I understand this can feel overwhelming. " +
                               "Take it one step at a time — I'm here to help.\n\n";
                    case "positive":
                        return "Glad you're feeling good! Let's keep that energy going. ";
                    default:
                        return "";
                }
            }
        }
    }

