using System;
using System.Collections.Generic;
using System.Text;
using TgcViewer.Example;
using TgcViewer;
using Microsoft.DirectX.Direct3D;
using System.Drawing;
using Microsoft.DirectX;
using TgcViewer.Utils.Modifiers;
using TgcViewer.Utils.TgcGeometry;
using TgcViewer.Utils.Input;
using TgcViewer.Utils.TgcSceneLoader;
using Microsoft.DirectX.DirectInput;
using AlumnoEjemplos.MiGrupo.Entities;
using TgcViewer.Utils.TgcSkeletalAnimation;

namespace AlumnoEjemplos.MiGrupo
{
    public class EjemploAlumno : TgcExample
    {
        TgcScene taxiScene;
        TgcScene ciudadScene;

        public override string getCategory()
        {
            return "AlumnoEjemplos";
        }

        /// <summary>
        /// Completar nombre del grupo en formato Grupo NN
        /// </summary>
        public override string getName()
        {
            return "Grupo LOS_BARTO";
        }

        public override string getDescription()
        {
            return "CrazyTaxi - Un taxi que debe llevar pasajeros de un punto de la ciudad a otro en un tiempo establecido al menos 5 veces.";
        }

        public override void init()
        {
            Microsoft.DirectX.Direct3D.Device d3dDevice = GuiController.Instance.D3dDevice;

            //Carpeta de archivos Media del alumno

            string alumnoMediaFolder = GuiController.Instance.AlumnoEjemplosMediaDir;
            //primero cargamos una escena 3D entera.
            TgcSceneLoader loader = new TgcSceneLoader();

            //Luego cargamos otro modelo aparte que va a hacer el taxi
            taxiScene = loader.loadSceneFromFile(alumnoMediaFolder + "LOS_BARTO\\taxi\\taxi-TgcScene.xml");
            //Cargamos la ciudad
            ciudadScene = loader.loadSceneFromFile(alumnoMediaFolder + "LOS_BARTO\\ciudad\\ciudad-TgcScene.xml");

            //solo nos interesa el taxi
            Auto.getInstance().inicializar(taxiScene.Meshes[0]);
            Flecha.getInstance().inicializar();
            Flecha.getInstance().show();

            Camara.inicializar(Auto.getInstance().getPosicion());

            GameControl.getInstance().inicializar();

            GuiController.Instance.UserVars.addVar("posPas");
            GuiController.Instance.UserVars.addVar("posTaxi", Auto.getInstance().getMesh().Position);
            GuiController.Instance.UserVars.addVar("posDest");
            GuiController.Instance.UserVars.addVar("velocidad");
            GuiController.Instance.UserVars.addVar("DistTaxi");
            GuiController.Instance.UserVars.addVar("distDest");
            //GuiController.Instance.UserVars.addVar("ptosRec");// punto en el q esta el recorrido del auto
            GuiController.Instance.UserVars.addVar("DistpRec");

            //Modifier para habilitar o no el renderizado del BoundingBox del personaje
            GuiController.Instance.Modifiers.addBoolean("showBoundingBox", "Bouding Box", false);
        }

        public override void render(float elapsedTime)
        {
            //Ver si hay que mostrar el BoundingBox
            bool showBB = (bool)GuiController.Instance.Modifiers.getValue("showBoundingBox");

            Teclado.handlear();
            Auto.getInstance().checkCollision(ciudadScene);
            Auto.getInstance().render(elapsedTime);
            Flecha.getInstance().render(elapsedTime);

            ciudadScene.renderAll();

            GameControl.getInstance().render(elapsedTime);
        }

        public override void close()
        {
            Auto.getInstance().getMesh().dispose();
            ciudadScene.disposeAll();

            GameControl.getInstance().disposeAll();
        }
    }
}