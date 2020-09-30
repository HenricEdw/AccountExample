namespace AccountExample
{
    public class Person
    {
		private string m_name;
		private string m_sociSecNo;

		//Namn ska man inte kunna ändra direkt på personobjektet
		public string Name
		{
			get { return m_name; }
			private set { m_name = value; }
		}

		public string SociSecNo
		{
			get { return m_sociSecNo; }
			private set { m_sociSecNo = value; }
		}

		//En person ska ALLTID skapas med ett namn och en personnummer
		public Person(string name, string socNo)
		{
			m_name = name;
			m_sociSecNo = socNo;
		}
	}
}