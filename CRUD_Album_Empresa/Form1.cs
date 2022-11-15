using MySql.Data.MySqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Runtime.CompilerServices;

using System.Drawing;
using System.Drawing.Imaging;
namespace CRUD_Album_Empresa
{
    public partial class Album : Form
    {
        public Album()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtcodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            
            MemoryStream ms = new MemoryStream();
            pbimagen.Image.Save(ms,ImageFormat.Png);
            byte[] aByte = ms.ToArray();                     
            MySqlConnection conexionBD = Conexion.Conectarse();
            conexionBD.Open();

            try
            {
                
                MySqlCommand comando = new MySqlCommand("INSERT INTO fotos_eventos(codigo,descripcion_imagen,descripcion_evento,lugar_evento,fecha_evento,foto) VALUES('" + txt_codigo.Text+ "','" + txtdescripcion.Text+ "','" + txt_evento.Text + "','" + txt_lugar.Text + "','" + txt_fecha.Text+ "',@foto)",conexionBD);

                comando.Parameters.AddWithValue("foto", aByte);
                comando.ExecuteNonQuery();
                MessageBox.Show("registro guardado");
                pbimagen.Image = null;
                limpiar();


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error al guardar datos..." + ex.Message);

            }
            finally
            {
                conexionBD.Close();
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txt_desc_img_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_fecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtdescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn_borrar_Click(object sender, EventArgs e)
        {
            String id = txt_id.Text;





            string sql = "DELETE FROM fotos_eventos  WHERE id='" + id + "'";
            MySqlConnection conexionBD = Conexion.Conectarse();
            conexionBD.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("registro eliminado");
                limpiar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error al eliminar datos..." + ex.Message);

            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void limpiar()
        {
            txt_id.Text = "";
            txt_codigo.Text = "";
            txtdescripcion.Text = "";
            txt_evento.Text = "";
            txt_lugar.Text = "";
            txt_fecha.Text = "";
            pbimagen.Image = null;
           




        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
           

            String codigo = txt_codigo.Text;
           
            string sql = "SELECT id,codigo, descripcion_imagen, descripcion_evento, lugar_evento, fecha_evento,foto FROM fotos_eventos WHERE codigo='" + codigo + "' ";
            MySqlConnection conexionBD = Conexion.Conectarse();
            conexionBD.Open();
            try
            {
                

                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                MySqlDataReader reader = comando.ExecuteReader();
              
                limpiar();


                if (reader.HasRows)
                {
                    reader.Read();
                    txt_id.Text = reader["id"].ToString();

                    txt_codigo.Text = reader["codigo"].ToString();
                    txtdescripcion.Text = reader["descripcion_imagen"].ToString();
                    txt_evento.Text = reader["descripcion_evento"].ToString();
                    txt_lugar.Text = reader["lugar_evento"].ToString();
                    txt_fecha.Text = reader["fecha_evento"].ToString();
                    MemoryStream ms = new MemoryStream((byte[])reader["foto"]);
                    Bitmap bm = new Bitmap(ms);
                    pbimagen.Image = bm;





                }
                else
                {
                    MessageBox.Show("no se encontro registro");              
                }



            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Error al Buscar" + MessageBox.Show(ex.Message));
            }

        }

        private void txt_fecha_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void btnfoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes |*.jpg; *.png";
           ofdSeleccionar.InitialDirectory =  Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            
            if(ofdSeleccionar.ShowDialog()==DialogResult.OK){

               pbimagen.Image = Image.FromFile(ofdSeleccionar.FileName);

            }
        }

        private void picfoto_Click(object sender, EventArgs e)
        {

        }

        private void txt_codigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            {
                String id = txt_id.Text;
                String codigo = txt_codigo.Text;
                String descripcion_imagen = txtdescripcion.Text;
                String descripcion_evento = txt_evento.Text;
                String lugar_evento = txt_lugar.Text;
                String fecha_evento = txt_fecha.Text;
                MemoryStream ms = new MemoryStream();
                pbimagen.Image.Save(ms, ImageFormat.Jpeg);
                byte[] aByte = ms.ToArray();


                string sql = " UPDATE fotos_eventos SET codigo='" + codigo + "',descripcion_imagen='" + descripcion_imagen + "',descripcion_evento='" + descripcion_evento + "',lugar_evento='" + lugar_evento + "',fecha_evento='" + fecha_evento + "',foto=@foto WHERE id='" + id + "'";

                MySqlConnection conexionBD = Conexion.Conectarse();
                conexionBD.Open();
                try
                {
                    MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                    comando.Parameters.AddWithValue("foto", aByte);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("registro actualizado");
                    pbimagen.Image = null;
                    limpiar();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("error al actualizar datos..." + ex.Message);

                }
                finally
                {
                    conexionBD.Close();
                }


            }

        }

        private void txt_id_TextChanged(object sender, EventArgs e)
        {

        }
    }
}