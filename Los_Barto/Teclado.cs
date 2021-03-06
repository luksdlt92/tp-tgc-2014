﻿using AlumnoEjemplos.Los_Barto.Enums;
using Microsoft.DirectX.DirectInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TgcViewer;
using TgcViewer.Utils.Input;

namespace AlumnoEjemplos.Los_Barto
{
    public class Teclado
    {
        /// <summary>
        /// Manejador del teclado: todos los objetos que
        /// lo necesiten, se comunican con el teclado por medio
        /// de la esta clase
        /// </summary>

        Microsoft.DirectX.Direct3D.Device d3dDevice = GuiController.Instance.D3dDevice;
        static TgcD3dInput input = GuiController.Instance.D3dInput;

        private static bool _right;
        private static bool _left;
        private static bool _up;
        private static bool _down;
        private static bool _space;
        private static bool _playbocina;
        public static void handlear()
        {
            //Inputs
            _right = input.keyDown(Key.Right) || input.keyDown(Key.D);
            _left = input.keyDown(Key.Left) || input.keyDown(Key.A);
            _up = input.keyDown(Key.Up) || input.keyDown(Key.W);
            _down = input.keyDown(Key.Down) || input.keyDown(Key.S);
            _space = input.keyDown(Key.Space);
            _playbocina = input.keyDown(Key.B);
        }

        public static bool getInput(InputType input)
        {
            bool result = false;

            switch(input)
            {
                case InputType.UP:
                    result = _up;
                    break;
                case InputType.DOWN:
                    result = _down;
                    break;
                case InputType.RIGHT:
                    result = _right;
                    break;
                case InputType.LEFT:
                    result = _left;
                    break;
                case InputType.SPACE:
                    result = _space;
                    break;
                case InputType.BOCINA:
                    result = _playbocina;
                    break;
                default:
                    result = false;
                    break;
            }

            return result;
        }
    }
}
