using Newtonsoft.Json;
using System.Xml.Linq;

namespace XMLtoJSON

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox2.Text = XMLtoJSON(richTextBox1.Text);
            }
            catch (Exception ex)
            {
                richTextBox1.Text = ex.Message + ":" + ex.InnerException;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox2.Text = JSONtoXML(richTextBox1.Text);
            }
            catch (Exception ex)
            {
                richTextBox1.Text = ex.Message + ":" + ex.InnerException;
            }
        }

        public static string XMLtoJSON(string xml)
        {
            try
            {
                var doc = XDocument.Parse(xml);
                return JsonConvert.SerializeXNode(doc, Formatting.Indented);
            }
            catch (Exception)
            {
                // Handle and throw if fatal exception here; don't just ignore them
                return xml;
            }
        }

        private static readonly XDeclaration _defaultDeclaration = new("1.0", null, null);

        public static string JSONtoXML(string json)
        {
            try
            {
                var doc = JsonConvert.DeserializeXNode(json)!;

                var declaration = doc.Declaration ?? _defaultDeclaration;

                return $"{declaration}{Environment.NewLine}{doc}";
            }
            catch (Exception)
            {
                // Handle and throw if fatal exception here; don't just ignore them
                return json;
            }
        }
    }
}