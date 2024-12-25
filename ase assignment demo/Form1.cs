using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using BOOSE;

namespace ase_assignment_demo
{
    public partial class Form1 : Form
    {
        private MyCanvas canvas;

        public Form1()
        {
            InitializeComponent();
            Debug.WriteLine(AboutBOOSE.about());
            canvas = new MyCanvas(800, 600);
        }

        private void run_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the BOOSE program from the input
                string program = textBox1.Text;

                // Initialize BOOSE components
                var commandFactory = new CommandFactory();
                var storedProgram = new StoredProgram(canvas); // Pass canvas if required by constructor
                var parser = new Parser(commandFactory, storedProgram);

                // Parse the program
                // Replace 'Parse' with the correct method name based on the library
                parser.ParseProgram(program); // Hypothetical method name

                // Execute the stored program
                // Replace 'Execute' with the correct method name based on the library
                storedProgram.Run(); // Hypothetical method name

                // Display output in PictureBox
                pictureBox1.Image = (Bitmap)canvas.getBitmap();
                Debug.WriteLine("Program executed successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Handle text changes if needed
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Handle PictureBox clicks if needed
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
