using ChessAnimation.Models;
using ChessAnimation.Utility;
using ObjLoader.Loader.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Resources.ResXFileRef;

namespace ChessAnimation.ObjHelpers
{
	internal class Loaders
	{
		public static LoadResult loadObj(string fileName)
		{
			var objLoaderFactory = new ObjLoaderFactory();
			var objLoader = objLoaderFactory.Create();

			string path = Path.Combine(new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.FullName, @"Props\", fileName);

			FileStream fileStream = new FileStream(path, FileMode.Open);
			LoadResult? loadResult = objLoader.Load(fileStream);

			fileStream.Close();

			return loadResult;
		}

		public static List<Polygon> loadObjNormaliseAndMakePolys(string fileName, int width, int heigth)
		{
			LoadResult? loadResult = loadObj(fileName);

			List<Polygon> polygons = Polygon.makePolygonListFromLoadResult(loadResult);
			Converters.convertVerticesFromNormalizedObj(polygons, width, heigth);

			Parallel.ForEach(polygons, polygon => polygon.calculateDenominator());

			return polygons;
		}

		public static List<Polygon> loadObjAndMakePolys(string fileName)
		{
			LoadResult? loadResult = loadObj(fileName);

			List<Polygon> polygons = Polygon.makePolygonListFromLoadResult(loadResult);

			Parallel.ForEach(polygons, polygon => polygon.calculateDenominator());

			return polygons;
		}

		public static void loadObject(ProjectData projectData, string obj)
		{
			List<Polygon> polygons = loadObjAndMakePolys(obj);
			Object3D object3D = new Object3D(polygons, obj);
			projectData.objects.Add(object3D);
		}
	}
}
