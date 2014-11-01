﻿using Microsoft.DirectX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TgcViewer;
using TgcViewer.Utils.TgcGeometry;
using TgcViewer.Utils.TgcSceneLoader;

namespace AlumnoEjemplos.MiGrupo
{
    public class Flecha
    {

        private Vector3 _direccion = new Vector3(0, 0, -1);
        private Vector3 _objetivo;
        private Boolean _show = false;
        private static Flecha _instance;
        private TgcBox _mesh;

        public void inicializar()
        {
            Vector3 size = new Vector3(2, 2, 10);
            Vector3 _position = new Vector3(Auto.getInstance().getMesh().Position.X, 75, Auto.getInstance().getMesh().Position.Z);
            _mesh = TgcBox.fromSize(_position, size);
        }

        public void setPosition(Vector3 pos)
        {
            _mesh.Position = pos;
        }
        public Vector3 getPosition()
        {
            return this.getMesh().Position;
        }
        public TgcBox getMesh()
        {
            return _mesh;
        }

        public void rotate()
        {
            float angle = -FastMath.PI_HALF - Utils.calculateAngle(this.getPosition().X, this.getPosition().Z, _objetivo.X, _objetivo.Z);
            float antiRotate = _mesh.Rotation.Y;
            _mesh.rotateY(angle - antiRotate);

        }

        public void show()
        {
            _show = true;
        }

        public void hide()
        {
            _show = false;
        }

        public void render(float elapsedTime)
        {
            this.setPosition(new Vector3(Auto.getInstance().getMesh().Position.X, 75, Auto.getInstance().getMesh().Position.Z));
            if (_objetivo != Auto.getInstance().getObjetivo() || _objetivo == null)
            {
                _objetivo = Auto.getInstance().getObjetivo();
            }
            if (_show)
            {
                this.rotate();
                _mesh.render();
            }
        }

        public static Flecha getInstance()
        {
            if (_instance == null)
            {
                _instance = new Flecha();
            }

            return _instance;
        }
    }
}
