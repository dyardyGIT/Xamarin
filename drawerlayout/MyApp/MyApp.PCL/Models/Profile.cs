using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.PCL.Models
{
    public class MyProfile
    {
        public List<MyDetail> AboutInformation { get; set; }
        
        public MyProfile()
        {
            AboutInformation = new List<MyDetail>();


            AboutInformation.Add(new MyDetail {
                Image= "license_sm",
                Title = "Engineering",
                Detail = @"
                        An engineer by training and a software developer at heart. My techniques and approaches meld engineering approaches with software technology. Core to these principles is a systematic approach to the development of software with a strong lifecycle and process management emphasis through adoption of mature technologies. 
                        Ten years designing heavy structural steel and concrete structures and 12 years in the software development profession have embedded strong project management and business knowledge in my approaches. 
                        To a client, it means you've got the credentials to earn their trust. To an employer, it signals your ability to take on a higher level of responsibility. Among your colleagues, it demands respect. To yourself, it's a symbol pride and measure of your own hard-won achievement. To become licensed, engineers must complete a four-year college degree, work under a Professional Engineer for at least four years, pass two intensive competency exams and earn a license from their state's licensure board. Then, to retain their licenses, PEs must continually maintain and improve their skills throughout their careers. Yet the results are well worth the effort. By combining their specialized skills with their high standards for ethics and quality assurance, PEs help make us healthier, keep us safer and allow all of us to live better lives than ever before. - See more at: http://www.nspe.org/resources/licensure/what-pe#sthash.kxamXmNe.dpuf	
                        What makes a PE different from an engineer? 
                        PEs must also continuously demonstrate their competency and maintain and improve their skills by fulfilling continuing education requirements depending on the state in which they are licensed. - See more at: http://www.nspe.org/resources/licensure/what-pe#sthash.kxamXmNe.dpuf
                        "
            });

            AboutInformation.Add(new MyDetail {
                Image = "mcsd_rgb_sm",
                Title = "Certification",
                Detail = @"The Microsoft Certified Solutions Developer is Microsoft's prevailing certification for programmers and application developers. The MCSD covers current Visual Studio versions (for the MCSD: Application Lifecycle Management cert) and also emphasizes HTML5, CSS3, JavaScript, C#, ASP.NET, Azure, Web Services, and SharePoint. "
            });

            AboutInformation.Add(new MyDetail {
                Image = "mcp_rgb_sm",
                Title = "Professional",
                Detail = @"Microsoft Certified Professional (MCP) is a certification that validates IT professional and developer technical expertise through rigorous, industry-proven, and industry-recognized exams. MCP exams cover a wide range of Microsoft products, technologies, and solutions. There are many branches of technological services that build off this basic Microsoft Certified (MC) certification; IT Professional (MCITP), architect (MCA), professional developer (MCPD), technology specialist (MCTS), systems administrator (MCSA), systems engineer (MCSE), solution developer (MCSD) and database administrator (MCDBA). Each branch builds off the competency and knowledge of Microsoft products and technology."
            });

            AboutInformation.Add(new MyDetail {
                Image = "queenslogo_colour_sm",
                Title = "University",
                Detail = @"Graduated Bachelor of Science with Honours - Faculty of Applied Science/Engineering Queen’s University is a community, 170 years of tradition, academic excellence, research, and beautiful waterfront campus made of limestone buildings and modern facilities. But more than anything Queen’s is people. We are researchers, scholars, artists, professors and students with an ambitious spirit who want to develop ideas that can make a difference in the world. People who imagine together what the future could be and work together to realize it. Queen’s is one of Canada’s oldest degree-granting institutions, and has influenced Canadian higher education since 1841 when it was established by Royal Charter of Queen Victoria. Located in Kingston, Ontario, Canada, it is a mid-sized university with several faculties, colleges and professional schools, as well as the Bader International Study Centre located in Herstmonceux, East Sussex, United Kingdom. Queen’s balances excellence in undergraduate studies with well-established and innovative graduate programs, all within a dynamic learning environment."
            });
            AboutInformation.Add(new MyDetail {
                Image = "naui_logo_sm",
                Title = "Hobbies",
                Detail = @"Certified NAUI Scuba Diver NAUI started in 1959 is the oldest recreational scuba certification agency. NAUI is a non-profit association which was started for the promotion of dive safety through education. Its diver courses are very similar to that conducted by PADI and SSI and it enjoys a status of being the second largest scuba certification agency after PADI. NAUI boasts of a no. of celebrities and industry pioneers certified by them like Kevin Costner, Tiger Woods (NAUI divemaster member), Cameron Diaz, Jacques-Yves Cousteau (inventor of the aqualung) and many more. Many of whom have popularized the activity for NAUI. As of 1997 NAUI published standards for teaching technical diving as well."
            });

        }
    }

    
    public class MyDetail { 

        public string Image { get; set; }
        public string Detail { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {

            return Detail;
            //return base.ToString();
        }
    }
}
