using MyMessanger;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;


namespace WindowsFromsClient
{
    public partial class Form1 : Form
    {
        private static int MessageID = 0;
        private static string UserName;
        private static string Message;
        private static MessangerClientAPI API = new MessangerClientAPI();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            UserName = UserNameTB.Text;
            Message = MessageTB.Text;

            if ((UserName.Length > 1) && (Message.Length > 1))
            {
                MyMessanger.Message msg = new MyMessanger.Message(UserName, Message, DateTime.Now);
                API.SendMessage(msg);
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var getMessages = new Func<Task>(async () =>
            {
                MyMessanger.Message msg = await API.GetMessageHTTPAsync(MessageID);
                while (msg != null)
                {
                    MessagesLB.Items.Add(msg);
                    MessageID++;
                    
                    msg = await API.GetMessageHTTPAsync(MessageID);
                }
            });
            getMessages.Invoke();

        }
    }
}
