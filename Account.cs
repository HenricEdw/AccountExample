using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountExample
{
    public class Account
    {
        //jag väljer att använda decimal för amount pga högre precision. Double går såklart utmärkt
        private decimal m_amount;
        //Jag väljer också att skapa en ny klass för kontoägare. Jag vill nog hålla ordning på mer än bara ett namn tex
        //och då blir det mer praktiskt med en egen klass för det
        private Person m_accountHolder;
        private decimal m_interestRate;
        
        //Amount, eller saldo ska bara kunna ändras via metoderna Withdraw eller Deposit.
        //Därför en private set
        public decimal Amount
        {
            get { return m_amount; }
            private set { m_amount = value; }
        }

        public Person AccountHolder
        {
            get { return m_accountHolder; }
            private set { m_accountHolder = value; }
        }

        public decimal InterestRate
        {
            get { return m_interestRate; }
            private set { m_interestRate = value; }
        }

        //Jag vill att kontohavare ska skapas direkt när kontot skapas. Ett konto ska aldrig få byta
        //ägare i mitt fall. Därför skapar jag en konstruktor som tvingar den som använder
        //account-klassen att instansiera och skapa en Person-instans som sedan måste skickas in i
        //konstruktorn så att Account-instanser alltid har en valid AccountHolder
        //Här har jag också bestämt att räntan är fast och sätts direkt i konstruktorn
        public Account(Person accountHolder)
        {
            m_accountHolder = accountHolder;
            m_interestRate = 0.03M;
        }
        //Jag väljer att reurnera en bool som talar om huruvida det gick att ta ut pengar
        //dvs om saldot var större än det belopp man försöker ta ut
        public bool Withdraw(decimal amount)
        {
            bool couldWithdraw = true;
            if (amount > m_amount)
            {
                couldWithdraw = false;
            }
            else
            {
                m_amount -= amount;
            }

            return couldWithdraw;
        }
        //Vi gör det enkelt för oss och bara lägger till det belopp vi försöker sätta in till kontots saldo
        public void Deposit(decimal amount)
        {
            m_amount += amount;
        }

        public decimal CalculateInterestForAccount()
        {
            decimal interestAmount = (m_amount * m_interestRate);
            m_amount += interestAmount;

            //Vi returnerar det faktiska pengavärdet som vår ränta har gett i påslag
            return interestAmount;
        }
        //Om vi mot förmodan vill byta räntesats måste det göras via denna metoden.
        public decimal ChangeInterestRate(decimal newInterest)
        {
            if (newInterest > 0)
                m_interestRate = newInterest;

            //Jag väljer här att returnera värdet på instansvariablen så kan den kod som försöker
            //anropa ränteändringsmetoden iaf kontrollera att det ändrats som man vill direkt. Annars kan man ju också
            //använda propertyn InterestRate för det.
            return m_interestRate;
        }

    }
}
