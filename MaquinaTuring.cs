using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaquinaDeTuring
{
    public partial class Form1 : Form
    {
        
        char[] CadenaSelecionada;
        char[] Alfabeto;
        char[] AlfabetoMin;
        char[] AlfabetoMax;
        char[] InstrucionesCorrer;
        string CadenaEpica, CadenaAlfabeto;
        string Instrucciones;
        int contador = 0;
        int Puntero = 1;
            int aux= 1;
        public Form1()
        {
            InitializeComponent();
            txtNumRandoms.Enabled = false;
            btnRandom.Enabled = false;
            btnAñadir.Enabled = true;
            txtCadena.Enabled = true;


            dtgCadena.Columns.Add("Indice", "Indice");
            dtgCadena.Columns.Add("Valor", "Valor");
            dtgCadena.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgCadena.MultiSelect = false;
            dtgCadena.ReadOnly = true;
            dtgCadena.AllowUserToResizeRows = false;
            dtgCadena.AllowUserToAddRows = false;
            dtgCadena.AllowUserToDeleteRows = false;
            dtgCadena.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgCadena.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgCadena.MultiSelect = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                CadenaAlfabeto = txtLetrasValidas.Text;
                CadenaAlfabeto = CadenaAlfabeto + "Δ";
                int longitud = CadenaAlfabeto.Length;
                Alfabeto = new char[longitud];
                AlfabetoMax = new char[longitud];
                AlfabetoMin = new char[longitud];
                for (int i = 0; i < Alfabeto.Length; i++)
                {
                    Alfabeto[i] = CadenaAlfabeto[i];
                    AlfabetoMax[i] = CadenaAlfabeto[i];
                    AlfabetoMin[i] = CadenaAlfabeto[i];

                }
                //Alfabeto[(longitud-1)] = 'Δ';



                string auxCadenaalfabeto = "";
                for (int i = 0; i < Alfabeto.Length; i++)
                {
                    auxCadenaalfabeto = auxCadenaalfabeto + Alfabeto[i];


                    cboAlfabeto.Items.Add(Alfabeto[i]);

                }
                
                

                for (int i = 0; i < AlfabetoMax.Length; i++)
                {
                    AlfabetoMax[i] = char.ToUpper(AlfabetoMax[i]);
                }

                for (int i = 0; i < AlfabetoMin.Length-1; i++)
                {

                    AlfabetoMin[i] = char.ToLower(AlfabetoMin[i]);
                }



                cboAlfabeto.SelectedIndex = 0;
                cboAcciones.SelectedIndex = 0;
                CadenaAlfabeto = "";
                CadenaAlfabeto = auxCadenaalfabeto;
                txtLetrasValidas.Text = "";
                txtLetrasValidas.Text = auxCadenaalfabeto;
                grbAlfabeto.Enabled = false;
                
            }
            catch (Exception X)
            {

                MessageBox.Show(X.Message);
            }
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            if (txtNumRandoms.Text != "")
            {
                /* string CadenaAlfabeto = txtLetrasValidas.Text;
                CadenaAlfabeto = CadenaAlfabeto + "Δ";
                int longitud = CadenaAlfabeto.Length+2;
                Alfabeto = new char[longitud];
                Alfabeto[0] = '@';
                Alfabeto[longitud-1] = '@';
                int j = 0;
                for (int i = 1; i < Alfabeto.Length-1; i++)
                {
                   
                        Alfabeto[i] = CadenaAlfabeto[j];
                        MessageBox.Show("Test " + CadenaAlfabeto[j] );
                    j++;
                    
                }
                 * 
                 */
                int numeroRadom = int.Parse(txtNumRandoms.Text);
                Random r = new Random();

                CadenaSelecionada = new char[numeroRadom+2];
                CadenaSelecionada[0] = '@';
                CadenaSelecionada[CadenaSelecionada.Length-1] = '@';

                int j = 0;
                for (int i = 1; i < CadenaSelecionada.Length-1; i++)
                {

                    CadenaSelecionada[i] = Alfabeto[r.Next(0,Alfabeto.Length)]; 

                }

                string auxcanada = "";
                for (int i = 0; i < CadenaSelecionada.Length; i++)
                {
                    auxcanada = auxcanada + CadenaSelecionada[i];
                }

                txtCadenaConfigurable.Text = auxcanada;
                CargarData();
            }
            else
            {
                Random r = new Random();
                int numeroRadom = r.Next(30, 100);

                CadenaSelecionada = new char[numeroRadom];
                CadenaSelecionada[0] = '@';
                CadenaSelecionada[CadenaSelecionada.Length - 1] = '@';
                for (int i = 1; i < CadenaSelecionada.Length-1; i++)
                {

                    CadenaSelecionada[i] = Alfabeto[r.Next(0, Alfabeto.Length)];

                }
                string auxcanada = "";
                for (int i = 0; i < CadenaSelecionada.Length; i++)
                {
                    auxcanada = auxcanada + CadenaSelecionada[i];
                }

                txtCadenaConfigurable.Text = auxcanada;
                CargarData();
            }





        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                CadenaEpica = txtCadena.Text;
                CadenaSelecionada = new char[CadenaEpica.Length+2];
                CadenaSelecionada[0] = '@';
                CadenaSelecionada[CadenaSelecionada.Length - 1] = '@';
                int j = 0;
                for (int i = 1; i < CadenaSelecionada.Length-1; i++)
                {
                    CadenaSelecionada[i] = CadenaEpica[j];
                    j++;
                }
                string auxCanada = "";
                for (int i = 0; i < CadenaSelecionada.Length; i++)
                {
                    if (CadenaSelecionada[i] == ' ')
                    {
                        CadenaSelecionada[i] = 'Δ';
                    }
                    auxCanada = auxCanada + CadenaSelecionada[i];
                    
                }


                foreach (char charcito in CadenaSelecionada)
                {
                    for (int i = 0; i < Alfabeto.Length; i++)
                    {
                        if (charcito == Alfabeto[i])
                        {
                            contador++;
                        }
                        else
                        {
                           
                        }

                    }  
                    
                }
                if (contador == CadenaSelecionada.Length-2)
                {
                    txtCadena.Text = "";
                    txtCadena.Text = auxCanada;
                    txtCadenaConfigurable.Text = auxCanada;
                    MessageBox.Show("se registro la cadena");
                    contador = 0;
                    CargarData();
                }
                else
                {
                    txtCadena.Text = "";
                    MessageBox.Show("no paso");
                    contador = 0;
                }

               /* for (int i = 0; i < Alfabeto.Length; i++)
                {
                  

                        MessageBox.Show("alfabeto empieza en: " + Alfabeto[i]);
                        for (int j = 0; j < CadenaSelecionada.Length; j++)
                        {

                            if (CadenaSelecionada[j] != Alfabeto[i])
                            {

                                bandera = true;


                            }
                            else
                            {
                                bandera = false;
                               

                            }

                        }
                    

                }*/
              

               
                

                

            }
            catch (Exception Azteca)
            {

                MessageBox.Show(Azteca.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            /*
            Movimiento D
            Movimiento I
            Sobreescribir por 1 alfabeto
            Busqueda 1 alfabeto D
            Busqueda 1 alfabeto I
            Diferente al 1 alfabeto D
            Diferente al 1 alfabeto I 
            */
            string auxAcciones = "";

            cboAcciones.Text = auxAcciones;

            switch (cboAcciones.SelectedIndex)
            {
                case 0:
                    auxAcciones = ">";
                    break;
                case 1:
                    auxAcciones = "<";
                    break;
                case 2:
                    auxAcciones = cboAlfabeto.Text;
                    break;
                case 3:
                    auxAcciones = ">" + cboAlfabeto.Text;

                    break;
                case 4:
                    auxAcciones = "<" + cboAlfabeto.Text;
                    break;
                case 5:
                    auxAcciones = ">!" + cboAlfabeto.Text;
                    break;
                case 6:

                    auxAcciones = "<!" + cboAlfabeto.Text;
                    break;
                


                default:
                    break;
            }


            txtAcciones.Text =  txtAcciones.Text+ auxAcciones ;




        }

        private void btnCorrer_Click(object sender, EventArgs e)
        {
            /*
              dtgCadena.Rows[i].Cells[0].Style.BackColor = Color.White;
              dtgCadena.Rows[i].Cells[1].Style.BackColor = Color.White;
             
             */
            Instrucciones = txtAcciones.Text;
            int longitud = Instrucciones.Length;
            InstrucionesCorrer = new char[longitud];
            for (int i = 0; i < InstrucionesCorrer.Length; i++)
            {
                InstrucionesCorrer[i] = Instrucciones[i];
            }

            for (int i = 0; i < InstrucionesCorrer.Length; i++)
            {
                if (InstrucionesCorrer.Length == 1)
                {
                     //Mover a Derecha
                    if (InstrucionesCorrer[i] == '>')
                    {
                        if (CadenaSelecionada[Puntero + 1] == '@')
                        {
                            MessageBox.Show("ERROR FINAL O INICIO DE DEMILITADOR");
                            break;
                        }
                        else
                        {
                            dtgCadena.Rows[Puntero + 1].Cells[0].Style.BackColor = Color.Green;
                            dtgCadena.Rows[Puntero + 1].Cells[1].Style.BackColor = Color.Green;
                            MessageBox.Show("Mover a la derecha");
                            Puntero++;
                        }

                    }
                    //Mover a Izquierda
                    else if (InstrucionesCorrer[i] == '<')
                    {
                        if (CadenaSelecionada[Puntero - 1] == '@')
                        {
                            MessageBox.Show("ERROR FINAL O INICIO DE DEMILITADOR");
                            break;
                        }
                        else
                        {
                            dtgCadena.Rows[Puntero - 1].Cells[0].Style.BackColor = Color.Blue;
                            dtgCadena.Rows[Puntero - 1].Cells[1].Style.BackColor = Color.Blue;
                            Puntero--;
                            MessageBox.Show("Mover a la Izquierda");
                        }


                    }
                    //Sobrecribir
                    else if (Buscar(InstrucionesCorrer[i], InstrucionesCorrer, i))
                    {
                        dtgCadena.Rows[Puntero].Cells[1].Value = Instrucciones[i];
                        dtgCadena.Rows[Puntero].Cells[0].Style.BackColor = Color.Red;
                        dtgCadena.Rows[Puntero].Cells[1].Style.BackColor = Color.Red;
                        MessageBox.Show("Sobre escribir la celda actual con: " + InstrucionesCorrer[i] + " El puntero sigue siendo el mismo: ");

                    }
                }
                else if (InstrucionesCorrer.Length == 2)
                {
                    if (i == 0)
                    {
                        //Buscar a derecha
                        if (InstrucionesCorrer[i] == '>' && Buscar(InstrucionesCorrer[i + 1]))
                        {
                            for (int j = Puntero + 1; j < CadenaSelecionada.Length; j++)
                            {

                                if (CadenaSelecionada[j] == '@')
                                {
                                    MessageBox.Show("ERROR FINAL O INICIO DE DEMILITADOR");
                                    break;
                                }
                                else
                                {
                                    if (CadenaSelecionada[j] == InstrucionesCorrer[i + 1])
                                    {
                                        Puntero = j;
                                        dtgCadena.Rows[j].Cells[0].Style.BackColor = Color.Yellow;
                                        dtgCadena.Rows[j].Cells[1].Style.BackColor = Color.Yellow;
                                        MessageBox.Show("buscando a la derecha igual de: " + InstrucionesCorrer[i + 1]);
                                        break;
                                    }
                                    else
                                    {
                                        dtgCadena.Rows[j].Cells[0].Style.BackColor = Color.Green;
                                        dtgCadena.Rows[j].Cells[1].Style.BackColor = Color.Green;
                                        MessageBox.Show("Moviendose a la derecha..");
                                    }
                                }

                            }
                            i = i + 1;
                        }
                        //Buscar a Izquierda
                        else if (InstrucionesCorrer[i] == '<' && Buscar(InstrucionesCorrer[i + 1]))
                        {
                            for (int j = Puntero - 1; j < CadenaSelecionada.Length; j--)
                            {

                                if (CadenaSelecionada[j] == '@')
                                {
                                    MessageBox.Show("ERROR FINAL O INICIO DE DEMILITADOR");
                                    break;
                                }
                                else
                                {
                                    if (CadenaSelecionada[j] == InstrucionesCorrer[i + 1])
                                    {
                                        Puntero = j;
                                        dtgCadena.Rows[j].Cells[0].Style.BackColor = Color.Yellow;
                                        dtgCadena.Rows[j].Cells[1].Style.BackColor = Color.Yellow;
                                        MessageBox.Show("buscando a la izquierda igual de: " + InstrucionesCorrer[i + 1]);
                                        break;
                                    }
                                    else
                                    {
                                        dtgCadena.Rows[j].Cells[0].Style.BackColor = Color.Green;
                                        dtgCadena.Rows[j].Cells[1].Style.BackColor = Color.Green;
                                        MessageBox.Show("Moviendose a la izquierda..");
                                    }
                                }

                            }

                            i = i + 1;
                        }
                        //Mover a Derecha
                        else if (InstrucionesCorrer[i] == '>')
                        {
                            if (CadenaSelecionada[Puntero + 1] == '@')
                            {
                                MessageBox.Show("ERROR FINAL O INICIO DE DEMILITADOR");
                                break;
                            }
                            else
                            {
                                dtgCadena.Rows[Puntero + 1].Cells[0].Style.BackColor = Color.Green;
                                dtgCadena.Rows[Puntero + 1].Cells[1].Style.BackColor = Color.Green;
                                MessageBox.Show("Mover a la derecha");
                                Puntero++;
                            }

                        }
                        //Mover a Izquierda
                        else if (InstrucionesCorrer[i] == '<')
                        {
                            if (CadenaSelecionada[Puntero - 1] == '@')
                            {
                                MessageBox.Show("ERROR FINAL O INICIO DE DEMILITADOR");
                                break;
                            }
                            else
                            {
                                dtgCadena.Rows[Puntero - 1].Cells[0].Style.BackColor = Color.Blue;
                                dtgCadena.Rows[Puntero - 1].Cells[1].Style.BackColor = Color.Blue;
                                Puntero--;
                                MessageBox.Show("Mover a la Izquierda");
                            }


                        }
                        //Sobrecribir
                        else if (Buscar(InstrucionesCorrer[i], InstrucionesCorrer, i))
                        {
                            dtgCadena.Rows[Puntero].Cells[1].Value = Instrucciones[i];
                            dtgCadena.Rows[Puntero].Cells[0].Style.BackColor = Color.Red;
                            dtgCadena.Rows[Puntero].Cells[1].Style.BackColor = Color.Red;
                            MessageBox.Show("Sobre escribir la celda actual con: " + InstrucionesCorrer[i] + " El puntero sigue siendo el mismo: ");

                        }
                    }
                    else
                    {
                        //Mover a Derecha
                        if (InstrucionesCorrer[i] == '>')
                        {
                            if (CadenaSelecionada[Puntero + 1] == '@')
                            {
                                MessageBox.Show("ERROR FINAL O INICIO DE DEMILITADOR");
                                break;
                            }
                            else
                            {
                                dtgCadena.Rows[Puntero + 1].Cells[0].Style.BackColor = Color.Blue;
                                dtgCadena.Rows[Puntero + 1].Cells[1].Style.BackColor = Color.Blue;
                                MessageBox.Show("Mover a la derecha");
                                Puntero++;
                            }

                        }
                        //Mover a Izquierda
                        else if (InstrucionesCorrer[i] == '<')
                        {
                            if (CadenaSelecionada[Puntero - 1] == '@')
                            {
                                MessageBox.Show("ERROR FINAL O INICIO DE DEMILITADOR");
                                break;
                            }
                            else
                            {
                                dtgCadena.Rows[Puntero - 1].Cells[0].Style.BackColor = Color.Green;
                                dtgCadena.Rows[Puntero - 1].Cells[1].Style.BackColor = Color.Green;
                                Puntero--;
                                MessageBox.Show("Mover a la Izquierda");
                            }


                        }
                        //Sobrecribir
                        else if (Buscar(InstrucionesCorrer[i], InstrucionesCorrer, i))
                        {
                            dtgCadena.Rows[Puntero].Cells[1].Value = Instrucciones[i];
                            dtgCadena.Rows[Puntero].Cells[0].Style.BackColor = Color.Red;
                            dtgCadena.Rows[Puntero].Cells[1].Style.BackColor = Color.Red;
                            MessageBox.Show("Sobre escribir la celda actual con: " + InstrucionesCorrer[i] + " El puntero sigue siendo el mismo: ");

                        }
                    }
                }
                else
                {

                    if (i < InstrucionesCorrer.Length-2)
                    {
                        //Diferente a derecha
                        if (InstrucionesCorrer[i] == '>' && InstrucionesCorrer[i + 1] == '!' && Buscar(InstrucionesCorrer[i + 2], InstrucionesCorrer, i + 2))
                        {
                            for (int j = Puntero + 1; j < CadenaSelecionada.Length; j++)
                            {
                                if (CadenaSelecionada[j] == '@')
                                {
                                    MessageBox.Show("ERROR FINAL O INICIO DE DEMILITADOR");
                                    break;
                                }
                                else
                                {
                                    if (CadenaSelecionada[j] != InstrucionesCorrer[i + 2])
                                    {
                                        dtgCadena.Rows[j].Cells[0].Style.BackColor = Color.Green;
                                        dtgCadena.Rows[j].Cells[1].Style.BackColor = Color.Green;
                                        MessageBox.Show("Moviendose a la derecha..");
                                    }
                                    else
                                    {
                                        Puntero = j;
                                        dtgCadena.Rows[j].Cells[0].Style.BackColor = Color.Yellow;
                                        dtgCadena.Rows[j].Cells[1].Style.BackColor = Color.Yellow;
                                        MessageBox.Show("Diferente a derecha de: " + InstrucionesCorrer[i + 2]);
                                        break;
                                    }
                                }
                            }


                            i = i + 2;
                        }
                        //diferente a izquierda
                        else if (InstrucionesCorrer[i] == '<' && InstrucionesCorrer[i + 1] == '!' && Buscar(InstrucionesCorrer[i + 2], InstrucionesCorrer, i + 2))
                        {
                            for (int j = Puntero - 1; j < CadenaSelecionada.Length; j--)
                            {
                                if (CadenaSelecionada[j] == '@')
                                {
                                    MessageBox.Show("ERROR FINAL O INICIO DE DEMILITADOR");
                                    break;
                                }
                                else
                                {
                                    if (CadenaSelecionada[j] != InstrucionesCorrer[i + 2])
                                    {
                                        dtgCadena.Rows[j].Cells[0].Style.BackColor = Color.Blue;
                                        dtgCadena.Rows[j].Cells[1].Style.BackColor = Color.Blue;
                                        MessageBox.Show("Moviendose a la izquierda..");

                                    }
                                    else
                                    {
                                        Puntero = j;
                                        dtgCadena.Rows[j].Cells[0].Style.BackColor = Color.Yellow;
                                        dtgCadena.Rows[j].Cells[1].Style.BackColor = Color.Yellow;
                                        MessageBox.Show("Diferente a derecha de: " + InstrucionesCorrer[i + 2]);
                                        break;
                                    }
                                }
                            }

                            i = i + 2;
                        }
                        //Buscar a derecha
                        else if (InstrucionesCorrer[i] == '>' && Buscar(InstrucionesCorrer[i + 1]))
                        {
                            for (int j = Puntero + 1; j < CadenaSelecionada.Length; j++)
                            {

                                if (CadenaSelecionada[j] == '@')
                                {
                                    MessageBox.Show("ERROR FINAL O INICIO DE DEMILITADOR");
                                    break;
                                }
                                else
                                {
                                    if (CadenaSelecionada[j] == InstrucionesCorrer[i + 1])
                                    {
                                        Puntero = j;
                                        dtgCadena.Rows[j].Cells[0].Style.BackColor = Color.Yellow;
                                        dtgCadena.Rows[j].Cells[1].Style.BackColor = Color.Yellow;
                                        MessageBox.Show("buscando a la derecha igual de: " + InstrucionesCorrer[i + 1]);
                                        break;
                                    }
                                    else
                                    {
                                        dtgCadena.Rows[j].Cells[0].Style.BackColor = Color.Green;
                                        dtgCadena.Rows[j].Cells[1].Style.BackColor = Color.Green;
                                        MessageBox.Show("Moviendose a la derecha..");
                                    }
                                }

                            }
                            i = i + 1;
                        }
                        //Buscar a Izquierda
                        else if (InstrucionesCorrer[i] == '<' && Buscar(InstrucionesCorrer[i + 1]))
                        {
                            for (int j = Puntero - 1; j < CadenaSelecionada.Length; j--)
                            {

                                if (CadenaSelecionada[j] == '@')
                                {
                                    MessageBox.Show("ERROR FINAL O INICIO DE DEMILITADOR");
                                    break;
                                }
                                else
                                {
                                    if (CadenaSelecionada[j] == InstrucionesCorrer[i + 1])
                                    {
                                        Puntero = j;
                                        dtgCadena.Rows[j].Cells[0].Style.BackColor = Color.Yellow;
                                        dtgCadena.Rows[j].Cells[1].Style.BackColor = Color.Yellow;
                                        MessageBox.Show("buscando a la izquierda igual de: " + InstrucionesCorrer[i + 1]);
                                        break;
                                    }
                                    else
                                    {
                                        dtgCadena.Rows[j].Cells[0].Style.BackColor = Color.Blue;
                                        dtgCadena.Rows[j].Cells[1].Style.BackColor = Color.Blue;
                                        MessageBox.Show("Moviendose a la izquierda..");
                                    }
                                }

                            }

                            i = i + 1;
                        }
                        //Mover a Derecha
                        else if (InstrucionesCorrer[i] == '>')
                        {
                            if (CadenaSelecionada[Puntero + 1] == '@')
                            {
                                MessageBox.Show("ERROR FINAL O INICIO DE DEMILITADOR");
                                break;
                            }
                            else
                            {
                                dtgCadena.Rows[Puntero + 1].Cells[0].Style.BackColor = Color.Green;
                                dtgCadena.Rows[Puntero + 1].Cells[1].Style.BackColor = Color.Green;
                                MessageBox.Show("Mover a la derecha");
                                Puntero++;
                            }

                        }
                        //Mover a Izquierda
                        else if (InstrucionesCorrer[i] == '<')
                        {
                            if (CadenaSelecionada[Puntero - 1] == '@')
                            {
                                MessageBox.Show("ERROR FINAL O INICIO DE DEMILITADOR");
                                break;
                            }
                            else
                            {
                                dtgCadena.Rows[Puntero - 1].Cells[0].Style.BackColor = Color.Blue;
                                dtgCadena.Rows[Puntero - 1].Cells[1].Style.BackColor = Color.Blue;
                                Puntero--;
                                MessageBox.Show("Mover a la Izquierda");
                            }


                        }
                        //Sobrecribir
                        else if (Buscar(InstrucionesCorrer[i], InstrucionesCorrer, i))
                        {
                            dtgCadena.Rows[Puntero].Cells[1].Value = Instrucciones[i];
                            dtgCadena.Rows[Puntero].Cells[0].Style.BackColor = Color.Red;
                            dtgCadena.Rows[Puntero].Cells[1].Style.BackColor = Color.Red;
                            MessageBox.Show("Sobre escribir la celda actual con: " + InstrucionesCorrer[i] + " El puntero sigue siendo el mismo: ");

                        }
                    }
                    else if(i < InstrucionesCorrer.Length-1)
                    {
                        //Buscar a derecha
                        if (InstrucionesCorrer[i] == '>' && Buscar(InstrucionesCorrer[i + 1]))
                        {
                            for (int j = Puntero + 1; j < CadenaSelecionada.Length; j++)
                            {

                                if (CadenaSelecionada[j] == '@')
                                {
                                    MessageBox.Show("ERROR FINAL O INICIO DE DEMILITADOR");
                                    break;
                                }
                                else
                                {
                                    if (CadenaSelecionada[j] == InstrucionesCorrer[i + 1])
                                    {
                                        Puntero = j;
                                        dtgCadena.Rows[j].Cells[0].Style.BackColor = Color.Yellow;
                                        dtgCadena.Rows[j].Cells[1].Style.BackColor = Color.Yellow;
                                        MessageBox.Show("buscando a la derecha igual de: " + InstrucionesCorrer[i + 1]);
                                        break;
                                    }
                                    else
                                    {
                                        dtgCadena.Rows[j].Cells[0].Style.BackColor = Color.Green;
                                        dtgCadena.Rows[j].Cells[1].Style.BackColor = Color.Green;
                                        MessageBox.Show("Moviendose a la derecha..");
                                    }
                                }

                            }
                            i = i + 1;
                        }
                        //Buscar a Izquierda
                        else if (InstrucionesCorrer[i] == '<' && Buscar(InstrucionesCorrer[i + 1]))
                        {
                            for (int j = Puntero - 1; j < CadenaSelecionada.Length; j--)
                            {

                                if (CadenaSelecionada[j] == '@')
                                {
                                    MessageBox.Show("ERROR FINAL O INICIO DE DEMILITADOR");
                                    break;
                                }
                                else
                                {
                                    if (CadenaSelecionada[j] == InstrucionesCorrer[i + 1])
                                    {
                                        Puntero = j;
                                        dtgCadena.Rows[j].Cells[0].Style.BackColor = Color.Yellow;
                                        dtgCadena.Rows[j].Cells[1].Style.BackColor = Color.Yellow;
                                        MessageBox.Show("buscando a la izquierda igual de: " + InstrucionesCorrer[i + 1]);
                                        break;
                                    }
                                    else
                                    {
                                        dtgCadena.Rows[j].Cells[0].Style.BackColor = Color.Green;
                                        dtgCadena.Rows[j].Cells[1].Style.BackColor = Color.Green;
                                        MessageBox.Show("Moviendose a la izquierda..");
                                    }
                                }

                            }

                            i = i + 1;
                        }
                        //Mover a Derecha
                        else if (InstrucionesCorrer[i] == '>')
                        {
                            if (CadenaSelecionada[Puntero + 1] == '@')
                            {
                                MessageBox.Show("ERROR FINAL O INICIO DE DEMILITADOR");
                                break;
                            }
                            else
                            {
                                dtgCadena.Rows[Puntero + 1].Cells[0].Style.BackColor = Color.Green;
                                dtgCadena.Rows[Puntero + 1].Cells[1].Style.BackColor = Color.Green;
                                MessageBox.Show("Mover a la derecha");
                                Puntero++;
                            }

                        }
                        //Mover a Izquierda
                        else if (InstrucionesCorrer[i] == '<')
                        {
                            if (CadenaSelecionada[Puntero - 1] == '@')
                            {
                                MessageBox.Show("ERROR FINAL O INICIO DE DEMILITADOR");
                                break;
                            }
                            else
                            {
                                dtgCadena.Rows[Puntero - 1].Cells[0].Style.BackColor = Color.Blue;
                                dtgCadena.Rows[Puntero - 1].Cells[1].Style.BackColor = Color.Blue;
                                Puntero--;
                                MessageBox.Show("Mover a la Izquierda");
                            }


                        }
                        //Sobrecribir
                        else if (Buscar(InstrucionesCorrer[i], InstrucionesCorrer, i))
                        {
                            dtgCadena.Rows[Puntero].Cells[1].Value = Instrucciones[i];
                            dtgCadena.Rows[Puntero].Cells[0].Style.BackColor = Color.Red;
                            dtgCadena.Rows[Puntero].Cells[1].Style.BackColor = Color.Red;
                            MessageBox.Show("Sobre escribir la celda actual con: " + InstrucionesCorrer[i] + " El puntero sigue siendo el mismo: ");

                        }
                    }
                    else
                    {
                        
                        //Mover a Derecha
                        if (InstrucionesCorrer[i] == '>')
                        {
                            if (CadenaSelecionada[Puntero + 1] == '@')
                            {
                                MessageBox.Show("ERROR FINAL O INICIO DE DEMILITADOR");
                                break;
                            }
                            else
                            {
                                dtgCadena.Rows[Puntero + 1].Cells[0].Style.BackColor = Color.Green;
                                dtgCadena.Rows[Puntero + 1].Cells[1].Style.BackColor = Color.Green;
                                MessageBox.Show("Mover a la derecha");
                                Puntero++;
                            }

                        }
                        //Mover a Izquierda
                        else if (InstrucionesCorrer[i] == '<')
                        {
                            if (CadenaSelecionada[Puntero - 1] == '@')
                            {
                                MessageBox.Show("ERROR FINAL O INICIO DE DEMILITADOR");
                                break;
                            }
                            else
                            {
                                dtgCadena.Rows[Puntero - 1].Cells[0].Style.BackColor = Color.Blue;
                                dtgCadena.Rows[Puntero - 1].Cells[1].Style.BackColor = Color.Blue;
                                Puntero--;
                                MessageBox.Show("Mover a la Izquierda");
                            }


                        }
                        //Sobrecribir
                        else if (Buscar(InstrucionesCorrer[i], InstrucionesCorrer, i))
                        {
                            dtgCadena.Rows[Puntero].Cells[1].Value = Instrucciones[i];
                            dtgCadena.Rows[Puntero].Cells[0].Style.BackColor = Color.Red;
                            dtgCadena.Rows[Puntero].Cells[1].Style.BackColor = Color.Red;
                            MessageBox.Show("Sobre escribir la celda actual con: " + InstrucionesCorrer[i] + " El puntero sigue siendo el mismo: ");

                        }
                    }
                    

                }
            }
            



        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                CadenaEpica = txtCadenaConfigurable.Text;
                CadenaSelecionada = new char[CadenaEpica.Length];
                CadenaSelecionada[0] = '@';
                CadenaSelecionada[CadenaSelecionada.Length - 1] = '@';
                for (int i = 1; i < CadenaSelecionada.Length-1; i++)
                {
                    CadenaSelecionada[i] = CadenaEpica[i];
                }
                string auxCanada = "";
                for (int i = 0; i < CadenaEpica.Length; i++)
                {
                    if (CadenaSelecionada[i] == ' ')
                    {
                        CadenaSelecionada[i] = 'Δ';
                    }
                    auxCanada = auxCanada + CadenaSelecionada[i];

                }


                foreach (char charcito in CadenaSelecionada)
                {
                    for (int i = 0; i < Alfabeto.Length; i++)
                    {
                        if (charcito == Alfabeto[i])
                        {
                            contador++;
                        }
                        else
                        {

                        }

                    }

                }
                MessageBox.Show("Contador" + contador + "y cadena: " + CadenaSelecionada.Length);
                if (contador == CadenaSelecionada.Length-2)
                {
                    txtCadenaConfigurable.Text = "";

                    txtCadenaConfigurable.Text = auxCanada;
                    MessageBox.Show("se registro la cadena");
                    contador = 0;
                    CargarData();
                }
                else
                {
                   
                    MessageBox.Show("no paso");
                    contador = 0;
                }


            }
            catch (Exception Azteca)
            {

                MessageBox.Show(Azteca.Message);
            }
        }

        private void radManual_CheckedChanged(object sender, EventArgs e)
        {
            txtNumRandoms.Enabled = false;
            btnRandom.Enabled = false;
            btnAñadir.Enabled = true;
            txtCadena.Enabled = true;
        }

        private void radRandom_CheckedChanged(object sender, EventArgs e)
        {
            txtNumRandoms.Enabled = true;
            btnRandom.Enabled = true;
            btnAñadir.Enabled = false;
            txtCadena.Enabled = false;
        }

        private void cboAcciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            Movimiento D
            Movimiento I
            Sobreescribir por 1 alfabeto
            Busqueda 1 alfabeto D
            Busqueda 1 alfabeto I
            Diferente al 1 alfabeto D
            Diferente al 1 alfabeto I 
            */
            switch (cboAcciones.SelectedIndex)
            {
                case 0:
                    cboAlfabeto.Items.Clear();
                    for (int i = 0; i < AlfabetoMin.Length; i++)
                    {

                        cboAlfabeto.Items.Add(AlfabetoMin[i]);

                    }
                    cboAlfabeto.SelectedIndex = 0;
                    break;
                case 1:

                    cboAlfabeto.Items.Clear();
                    for (int i = 0; i < AlfabetoMin.Length; i++)
                    {

                        cboAlfabeto.Items.Add(AlfabetoMin[i]);

                    }
                    cboAlfabeto.SelectedIndex = 0;
                    break;
                case 2:

                    cboAlfabeto.Items.Clear();
                    for (int i = 0; i < AlfabetoMax.Length; i++)
                    {

                        cboAlfabeto.Items.Add(AlfabetoMax[i]);

                    }
                    cboAlfabeto.SelectedIndex = 0;
                    
                    break;
                case 3:

                    cboAlfabeto.Items.Clear();
                    for (int i = 0; i < AlfabetoMin.Length; i++)
                    {

                        cboAlfabeto.Items.Add(AlfabetoMin[i]);

                    }
                    cboAlfabeto.SelectedIndex = 0;


                    break;
                case 4:

                    cboAlfabeto.Items.Clear();
                    for (int i = 0; i < AlfabetoMin.Length; i++)
                    {

                        cboAlfabeto.Items.Add(AlfabetoMin[i]);

                    }
                    cboAlfabeto.SelectedIndex = 0;


                    break;
                case 5:

                    cboAlfabeto.Items.Clear();
                    for (int i = 0; i < AlfabetoMin.Length; i++)
                    {

                        cboAlfabeto.Items.Add(AlfabetoMin[i]);

                    }
                    cboAlfabeto.SelectedIndex = 0;

                    break;
                case 6:

                    cboAlfabeto.Items.Clear();
                    for (int i = 0; i < AlfabetoMin.Length; i++)
                    {

                        cboAlfabeto.Items.Add(AlfabetoMin[i]);

                    }
                    cboAlfabeto.SelectedIndex = 0;


                    break;
               
                

                default:
                    break;
            }
        }

        private void dtgCadena_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dtgCadena_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < CadenaSelecionada.Length; i++)
            {
                dtgCadena.Rows[i].Cells[0].Style.BackColor = Color.White;
                dtgCadena.Rows[i].Cells[1].Style.BackColor = Color.White;
            }
            dtgCadena.DefaultCellStyle.BackColor = Color.White;
            aux = Puntero;
            /*dtgCadena.Rows[aux].Cells[0].Style.BackColor = Color.Red;
            dtgCadena.Rows[aux].Cells[1].Style.BackColor = Color.Red;*/
            Puntero = e.RowIndex;
            dtgCadena.Rows[Puntero].Cells[0].Style.BackColor = Color.Yellow;
            dtgCadena.Rows[Puntero].Cells[1].Style.BackColor = Color.Yellow;
          
            

        }

        private void CargarData()
        {
            dtgCadena.Rows.Clear();
            for (int i = 0; i < CadenaSelecionada.Length; i++)
            {
                dtgCadena.Rows.Add(i,CadenaSelecionada[i]);
            }
            
            
        }
        private bool Buscar(char XD, char[] Ay,int I)
        {
            bool bandera = false;

            if (Ay[I] == XD)
            {
                bandera = true;
            }
            else
            {
                bandera = false;
            }

            return bandera;
        }

        private void btnreiniciar_Click(object sender, EventArgs e)
        {
            /*char[] CadenaSelecionada;
            char[] Alfabeto;
            char[] AlfabetoMin;
            char[] AlfabetoMax;
            char[] InstrucionesCorrer;*/
            CadenaEpica = "";
                CadenaAlfabeto ="" ;
            Instrucciones = "";
             contador = 0;
            Puntero = 0;
                aux = 0;
        }

        private void btnPintar_Click(object snder, EventArgs e)
        {


            /*dtgCadena.Rows[aux].Cells[0].Style.BackColor = Color.Blue;
            dtgCadena.Rows[aux].Cells[1].Style.BackColor = Color.Blue;*/
            for (int i = 0; i < CadenaSelecionada.Length; i++)
            {
                dtgCadena.Rows[i].Cells[0].Style.BackColor = Color.Green;
                dtgCadena.Rows[i].Cells[1].Style.BackColor = Color.Green;
            }
            /*dtgCadena.Rows[Puntero].Cells[0].Style.BackColor = Color.Red;
            MessageBox.Show("Puntero " + Puntero);
            dtgCadena.Rows[Puntero].Cells[1].Style.BackColor = Color.Red;*/


        }

        private bool Buscar(char XD)
        {
            bool bandera = false;

            for (int i = 0; i < AlfabetoMin.Length; i++)
            {

                if (XD == AlfabetoMin[i])
                {

                    bandera = true;
                
                }
            
            }
           

            return bandera;
        }

    }
}
