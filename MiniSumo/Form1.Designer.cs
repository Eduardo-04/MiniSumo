using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ArduinoControlApp
{
    public partial class Form1 : Form
    {
        private MySqlConnection connection;
        private const string connectionString = "server=localhost;user id=root;password=root;database=tu_base_de_datos;port=3306";
        private const string tableName = "nombres";
        private const string nameField = "nombre";

        public Form1()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor, ingresa un nombre.");
                return;
            }

            try
            {
                connection.Open();

                string query = $"INSERT INTO {tableName} ({nameField}) VALUES (@nombre)";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Nombre guardado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar nombre: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor, ingresa un nombre.");
                return;
            }

            try
            {
                connection.Open();

                string query = $"DELETE FROM {tableName} WHERE {nameField} = @nombre";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Nombre eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar nombre: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        private void InitializeComponent()
        {
            this.btnActivarArduino = new System.Windows.Forms.Button();
            this.btnDesactivarArduino = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.Button();
            this.btnEliminarNombre = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnActivarArduino
            // 
            this.btnActivarArduino.Location = new System.Drawing.Point(236, 176);
            this.btnActivarArduino.Name = "btnActivarArduino";
            this.btnActivarArduino.Size = new System.Drawing.Size(121, 41);
            this.btnActivarArduino.TabIndex = 0;
            this.btnActivarArduino.Text = "Activar";
            this.btnActivarArduino.UseVisualStyleBackColor = true;
            // 
            // btnDesactivarArduino
            // 
            this.btnDesactivarArduino.Location = new System.Drawing.Point(236, 223);
            this.btnDesactivarArduino.Name = "btnDesactivarArduino";
            this.btnDesactivarArduino.Size = new System.Drawing.Size(121, 38);
            this.btnDesactivarArduino.TabIndex = 1;
            this.btnDesactivarArduino.Text = "Desactivar";
            this.btnDesactivarArduino.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            this.txtNombre.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtNombre.Location = new System.Drawing.Point(451, 176);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(116, 41);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.Text = "Guardar";
            this.txtNombre.UseVisualStyleBackColor = true;
            // 
            // btnEliminarNombre
            // 
            this.btnEliminarNombre.Location = new System.Drawing.Point(451, 223);
            this.btnEliminarNombre.Name = "btnEliminarNombre";
            this.btnEliminarNombre.Size = new System.Drawing.Size(116, 38);
            this.btnEliminarNombre.TabIndex = 3;
            this.btnEliminarNombre.Text = "Eliminar";
            this.btnEliminarNombre.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Botones Arduino";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(448, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Botones Base de Datos";
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(879, 593);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminarNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnDesactivarArduino);
            this.Controls.Add(this.btnActivarArduino);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Button btnActivarArduino;
        private Button btnDesactivarArduino;
        private Button txtNombre;
        private Button btnEliminarNombre;
        private Label label1;
        private Label label2;
    }
}
