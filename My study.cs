using System;

namespace Flyweight
{
	public interface IHouse
	{
		int Stages { get; }
		void Build(float latitude, float longitude);
	}

	public class PanelHouse : IHouse
	{
		public int IHouse.Stages { get; private set; }

		public PanelHouse()
		{
			Stages = 16;
		}

		public void Build(float latitude, float longitude)
		{
			Console.WriteLine($"PanelHouse, stages = {Stages}; ({latitude}, {longitude}) ");
		}
	}

	public class BrickHouse : IHouse
	{
		public int Stages { get; private set; }

		public BrickHouse()
		{
			Stages = 5;
		}

		public void Build(float latitude, float longitude)
		{
			Console.WriteLine($"BrickHouse, stages = {Stages}; ({latitude}, {longitude}) ");
		}
	}

	public enum HouseType
	{
		Panel,
		Brick
	}

	public class HouseFactory
	{
		private Dictionary<HouseType, IHouse> _houses = new Dictionary<HouseType, IHouse>();

		public IHouse GetHouse(HouseType type)
		{
			if (_houses.ContainsKey(type))
			{
				return _houses[type];
			}

			switch (type)
			{
				case HouseType.Panel: _houses[type] = new PanelHouse(); break;
				case HouseType.Brick: _houses[type] = new BrickHouse(); break;
			}

			return _houses[type];
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			HouseFactory factory = new HouseFactory();

			float latitude = 45;
			float longitude = 333;

			// let's build 5 panel houses
			for (int i = 0; i < 5; i++)
			{
				IHouse panelHouse = factory.GetHouse(HouseType.Panel);
				panelHouse.Build(latitude, longitude);

				latitude += .5f;
				longitude += .5f;
			}

			// let's build 10 brick houses
			for (int i = 0; i < 10; i++)
			{
				IHouse brickHouse = factory.GetHouse(HouseType.Brick);
				brickHouse.Build(latitude, longitude);

				latitude += 1.5f;
				longitude += 1.5f;
			}

			Console.ReadKey();
		}
	}
}