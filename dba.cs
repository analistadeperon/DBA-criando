1- Criar Banco de dados

 

private void btnCriarBD_Click(object sender, EventArgs e)
  {
            /* define os parâmetros para o inputbox */
            string Prompt = "Informe o nome do Banco de Dados a ser criado.Ex: Teste.sdf";
            string Titulo = "Matheus Deperon";
            string Resultado = Interaction.InputBox(Prompt, Titulo, @"c:\dados\Agenda.sdf", 650, 350);
            /* verifica se o resultado é uma string vazia o que indica que foi cancelado. */
            if (Resultado != "")
            {
                'verifica se o nome informado contém  o texto ".sdf"
                if (!Resultado.Contains(".sdf"))
                {
                    MessageBox.Show("Informe a extensão .sdf no arquivo...");
                    return;
                }
                try
                {
                    string connectionString;
                    string nomeArquivoBD = Resultado;
                    string senha = "";
                    'verifica se o arquivo com o nome informado já existe
                    if (File.Exists(nomeArquivoBD))
                    {
                        if (MessageBox.Show("O arquivo já existe !. Deseja excluir e criar novamente ? ", "Excluir", MessageBoxButtons.YesNo,
 MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            File.Delete(nomeArquivoBD);
                        }
                        else
                        {
                            return;
                        }
                    }
                    'monta a string de conexão com o banco de dados
                    connectionString = string.Format("DataSource=\"{0}\"; Password='{1}'", nomeArquivoBD, senha);
                    if (MessageBox.Show("Será criado arquivo " +  connectionString  +" Confirma ? ", "Criar", MessageBoxButtons.YesNo,
 MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        SqlCeEngine SqlEng = new SqlCeEngine(connectionString);
                        SqlEng.CreateDatabase();
                        lblResultado.Text = "Banco de dados " + nomeArquivoBD + " com sucesso !";
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("A operação foi cancelada...");
            }
     }
