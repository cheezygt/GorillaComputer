﻿using GorillaComputer.Extension;
using GorillaComputer.Model;
using GorillaComputer.Tool;
using GorillaNetworking;
using System.Text;

namespace GorillaComputer.Function
{
    internal class TurnFunction : ComputerFunction
    {
        public override string Name => "Turn";

        public override string Description => "Use 'OPTION' keys to set mode - Use number keys to set speed";

        public override string GetFunctionText()
        {
            StringBuilder str = new();

            str.AppendLine($"Turn Type: {ComputerTool.TurnType}").AppendLine();

            str.AppendLine($"Turn Value: {ComputerTool.TurnValue}").AppendLine();

            return str.ToString();
        }

        public override void OnKeyPressed(GorillaKeyboardBindings key)
        {
            switch (key)
            {
                case GorillaKeyboardBindings.option1:
                    ComputerTool.TurnType = ComputerTool.ETurnMode.Snap;
                    UpdateMonitor();
                    break;

                case GorillaKeyboardBindings.option2:
                    ComputerTool.TurnType = ComputerTool.ETurnMode.Smooth;
                    UpdateMonitor();
                    break;

                case GorillaKeyboardBindings.option3:
                    ComputerTool.TurnType = ComputerTool.ETurnMode.None;
                    UpdateMonitor();
                    break;

                default:
                    if (key.TryParseNumber(out int number))
                    {
                        ComputerTool.TurnValue = number;
                        UpdateMonitor();
                    }
                    break;
            }
        }
    }
}
