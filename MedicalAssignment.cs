using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project
{
    enum Severity
    {
        High=1,Medium,Low
    }
    internal class Disease
    {
        public string DiseaseName { get; set; }
        public string DiseaseDescription { get; set; }
        public string Severe { get; set; }

        public List<Symptom> DiseaseSymptomList { get; set;}

    }

    class Symptom
    {
        public string SymptomName { get; set; }

        public string SymptomDescription { get; set; }
        public string DiseaseName { get; set; }



    }
     class RepoClass
    {

        public List<Disease> diseases = new List<Disease>();
       public  List<Symptom> symptoms = new List<Symptom>();
        public void AddDisease(Disease d) => diseases.Add(d);

        public void AddSymptom(Symptom symptom) => symptoms.Add(symptom);

        //public void AddSymptomToDisease(Disease disease ,Symptom symptom)
        // {
        //     foreach (var item in diseases)
        //     {

        //     }
        //     disease.DiseaseSymptomList.Add(symptom);
        // }
        public void AddSymptomsToDisease(Symptom symptom)
        {
            foreach (Disease item in diseases)
            {
                if (symptom.DiseaseName == item.DiseaseName)
                {
                    item.DiseaseSymptomList.Add(symptom);
                }
            }
        }

        //public Disease GetDiseaseOnName(String diseaseName)
        //{

        //    foreach (Disease item in diseases)
        //    {
        //        if (item.DiseaseName == diseaseName)
        //            return item;
        //    }
        //    return null;
        //}
        public HashSet<string> ReturnDiseases(string[] enteredsymptom)
        {
            HashSet<string> ret = new HashSet<string>();

            foreach (string item in enteredsymptom)
            {
                foreach (Symptom s in symptoms)
                {
                   if(item==s.SymptomName)
                        ret.Add(s.DiseaseName);
                }
            }

            //Disease[] NewDiseasearr = diseases.ToArray();
            //try
            //{
            //for (int i = 0; i < enteredsymptoms.Length; i++)
            //{
            //    for (int j = 0; j < NewDiseasearr.Length; j++)
            //    {
            //        var item = NewDiseasearr[j];
            //        for (int k = 0; k < item.DiseaseSymptomList.Count; k++)
            //        {
            //            if (enteredsymptoms[i] == item.DiseaseSymptomList.ElementAt(k).SymptomName)
            //            {
            //                ret.Add(item.DiseaseSymptomList.ElementAt(k).DiseaseName);
            //                k= item.DiseaseSymptomList.Count;
            //                j= NewDiseasearr.Length;
            //            }
            //        }
            //    }
            //}

            //}
            //catch (Exception e)
            //{

            //    Console.WriteLine(e.Message);
            //}
            
            return ret;
        }
    }
        public class UILayer
        {
            static RepoClass repo = new RepoClass();


           static string name = null;
            static public void UIComponent()
            {

            bool x ;
            do
            {
                Console.WriteLine("Enter 1 to add disease\nEnter 2 to add symptoms to added disease\nCheck Patient");

                int enteredVal = Int16.Parse(Console.ReadLine());
            
               x= Switches(enteredVal);

            } while (x);

            

            }

            //static int choice = UIComponent();

            static public Boolean Switches(int choice)
            {
                switch (choice)
                {

                case 1:
                        AddDiseaseHelper();
                    return true;
                       
                case 2:
                        AddSymptomHelper();
                    return true;
                case 3:
                        AddPatientHelper();
                   return true; 

                    default:
                    return false; 
                }
            }

           static private void AddPatientHelper()
            {
                Console.WriteLine("enter the patient name");
                name = Console.ReadLine();

                Console.WriteLine("Enter the symptoms of the patient each seperated by comma");

                string symp = Console.ReadLine();
                string[] enteredSymptoms = symp.Split(',');
            Console.WriteLine(enteredSymptoms.Length);

            // Console.WriteLine(repo.ReturnDiseases(enteredSymptoms).Count);
            HashSet<string> list = repo.ReturnDiseases(enteredSymptoms);

            Console.WriteLine(list.Count);
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }
            //   repo.ReturnDiseases(enteredSymptoms);

        }

          static  private void AddSymptomHelper()
            {
                if (repo.diseases.Count != 0)
                {
                    Console.WriteLine("diseases available to add symptoms");
                    foreach (var item in repo.diseases)
                    {
                        Console.WriteLine(item.DiseaseName);
                    }

                    Console.WriteLine("enter the name of the disease");
                    string name = Console.ReadLine();
                    bool temp = false;
                    foreach (var item in repo.diseases)
                    {
                        if (item.DiseaseName == name)
                            temp = true;
                    }
                    if (temp)
                    {
                        Console.WriteLine("enter the name of the symptom");
                        string symptom = Console.ReadLine();
                        Console.WriteLine("enter the description of the symptoms");
                        string desc = Console.ReadLine();

                        Symptom s = new Symptom { DiseaseName = name, SymptomDescription = desc, SymptomName = symptom };

                        repo.AddSymptom(s);
                        //repo.AddSymptomsToDisease(s);
                        Console.WriteLine("symptom added to the disease");


                    }
                        else Console.WriteLine(" disease not available with us to add symptom\nAdd disease first then add symptom");
                }
                else Console.WriteLine(" disease not available with us to add symptom\nAdd disease first then add symptom");

            }

          static  private void AddDiseaseHelper()
            {
                Console.WriteLine("enter the name of the disease");
                string name= Console.ReadLine();
                Console.WriteLine("enter the severity\nIn terms of high medium low");
                string symp = Console.ReadLine();
                Console.WriteLine("enter the description about disease");

                string desctiption= Console.ReadLine();
                Disease d = new Disease {DiseaseName=name,DiseaseDescription=desctiption,Severe=symp};

                repo.AddDisease(d);

                Console.WriteLine("disease added");
               
            }
        }

    public class MedicalHelper
    {

        static void Main(string[] args)
        {
            UILayer.UIComponent();
        }
    }
}

    




