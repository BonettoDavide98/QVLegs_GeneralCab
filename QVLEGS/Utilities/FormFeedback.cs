using HalconDotNet;
using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace QVLEGS.Utilities
{
    public partial class FormFeedback : Form
    {
        private readonly Utilities.HWndCtrlManager hWndCtrlManager = null;

        private UCTastieraMaiuscola UCMai = null;
        private UCTastieraNumerica UCNum = null;
        private UCTastieraMinuscola UCMin = null;

        //Costruttore richiede un immagine, il path di output, le impostazioni e il repaintLock
        public FormFeedback(HImage himage, string path, DataType.Impostazioni impostazioni, object repaintLock)
        {
            try
            {
                InitializeComponent();
                this.hWndCtrlManager = new Utilities.HWndCtrlManager(panelHImage, impostazioni, repaintLock);
                LoadReferencePicture();
                LoadCurrentPicture(himage);
                SelectSaveDirectory(path);
                richTextBox1.Select();
            }
            catch (UnauthorizedAccessException uaex)
            {
                MessageBox.Show("Livello di autorizzazione insufficente per accedere alla cartella predefinita\nseleziona un altra cartella o esegui questo programma come amministratore\n" + uaex.StackTrace);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nell'inizializzazione\n" + ex.StackTrace);
            }
        }

        //Carica l'immagine di riferimento dalle risorse
        private void LoadReferencePicture()
        {
            try
            {
                pictureBoxRiferimento.Image = QVLEGS.Properties.Resources.RiferimentoFeedback;
                var imageSize = pictureBoxRiferimento.Image.Size;
                var fitSize = pictureBoxRiferimento.ClientSize;
                pictureBoxRiferimento.SizeMode = imageSize.Width > fitSize.Width || imageSize.Height > fitSize.Height ?
                    PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel caricamento dell'immagine di riferimento\n" + ex.StackTrace);
                throw new Exception();
            }
        }

        //Carica l'immagine corrente passata come parametro
        public void LoadCurrentPicture(HImage himage)
        {
            try
            {
                this.hWndCtrlManager.DisplayModelGraphics(himage.CopyImage());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel caricamento dell'immagine corrente\n" + ex.StackTrace);
                throw new Exception();
            }
        }

        //Modifica la directory di salvataggio
        public void SelectSaveDirectory(string directory)
        {
            textBoxPath.Text = directory;
        }

        //Restituisce la directory di salvataggio
        private string GetSaveDirectory()
        {
            return textBoxPath.Text;
        }

        //Salva immagine e xml in file omonimi con estensioni rispettivamente tif e xml
        private void buttonConferma_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime d = DateTime.Now;


                if (!System.IO.Directory.Exists(GetSaveDirectory()))
                    System.IO.Directory.CreateDirectory(GetSaveDirectory());

                string fileName = System.IO.Path.Combine(GetSaveDirectory(), string.Format("{0}.tif", d.ToString("yyyyMMdd HH mm ss.fff")));

                this.hWndCtrlManager.GetImage().WriteImage("tiff", 255, fileName);

                string xmlfilename = System.IO.Path.Combine(GetSaveDirectory(), string.Format("{0}.xml", d.ToString("yyyyMMdd HH mm ss.fff")));
                
                XmlTextWriter textWriter = new XmlTextWriter(xmlfilename, new UTF8Encoding());
                textWriter.Formatting = Formatting.Indented;

                /*
                STRUTTURA XML

                <?xml version="1.0" encoding="utf-8"?>

                <Feedback>
                    <Element id="1">
                        <IsGood>true oppure false oppure N/A</IsGood>
                    </Element>
                    <Element id="2">
                        <IsGood>true oppure false oppure N/A</IsGood>
                    </Element>

                    ...

                    <Element id="10">
                        <IsGood>true oppure false oppure N/A</IsGood>
                    </Element>
                    <Notes>bla bla bla</Notes>
                </Feedback>
                */

                textWriter.WriteStartDocument();

                    textWriter.WriteStartElement("Feedback");


                         textWriter.WriteStartElement("Element");

                            textWriter.WriteAttributeString("id",null,"1");

                            textWriter.WriteStartElement("IsGood");
                                if (radioButton1Buono.Checked)
                                    textWriter.WriteString("true");
                                else if (radioButton1NonBuono.Checked)
                                    textWriter.WriteString("false");
                                else
                                    textWriter.WriteString("N/A");
                            textWriter.WriteEndElement();

                        textWriter.WriteEndElement();
                        

                        textWriter.WriteStartElement("Element");
                
                            textWriter.WriteAttributeString("id",null,"2");

                            textWriter.WriteStartElement("IsGood");
                                if (radioButton2Buono.Checked)
                                    textWriter.WriteString("true");
                                else if (radioButton2NonBuono.Checked)
                                    textWriter.WriteString("false");
                                else
                                    textWriter.WriteString("N/A");
                            textWriter.WriteEndElement();

                        textWriter.WriteEndElement();


                        textWriter.WriteStartElement("Element");
                
                            textWriter.WriteAttributeString("id",null,"3");

                            textWriter.WriteStartElement("IsGood");
                                if (radioButton3Buono.Checked)
                                    textWriter.WriteString("true");
                                else if (radioButton3NonBuono.Checked)
                                    textWriter.WriteString("false");
                                else
                                    textWriter.WriteString("N/A");
                            textWriter.WriteEndElement();

                        textWriter.WriteEndElement();


                        textWriter.WriteStartElement("Element");
                
                            textWriter.WriteAttributeString("id",null,"4");

                            textWriter.WriteStartElement("IsGood");
                                if (radioButton4Buono.Checked)
                                    textWriter.WriteString("true");
                                else if (radioButton4NonBuono.Checked)
                                    textWriter.WriteString("false");
                                else
                                    textWriter.WriteString("N/A");
                            textWriter.WriteEndElement();

                        textWriter.WriteEndElement();


                        textWriter.WriteStartElement("Element");
                
                            textWriter.WriteAttributeString("id",null,"5");

                            textWriter.WriteStartElement("IsGood");
                                if (radioButton5Buono.Checked)
                                    textWriter.WriteString("true");
                                else if (radioButton5NonBuono.Checked)
                                    textWriter.WriteString("false");
                                else
                                    textWriter.WriteString("N/A");
                            textWriter.WriteEndElement();

                        textWriter.WriteEndElement();


                        textWriter.WriteStartElement("Element");
                
                            textWriter.WriteAttributeString("id",null,"6");

                            textWriter.WriteStartElement("IsGood");
                                if (radioButton6Buono.Checked)
                                    textWriter.WriteString("true");
                                else if (radioButton6NonBuono.Checked)
                                    textWriter.WriteString("false");
                                else
                                    textWriter.WriteString("N/A");
                            textWriter.WriteEndElement();

                        textWriter.WriteEndElement();


                        textWriter.WriteStartElement("Element");
                
                            textWriter.WriteAttributeString("id",null,"7");

                            textWriter.WriteStartElement("IsGood");
                                if (radioButton7Buono.Checked)
                                    textWriter.WriteString("true");
                                else if (radioButton7NonBuono.Checked)
                                    textWriter.WriteString("false");
                                else
                                    textWriter.WriteString("N/A");
                            textWriter.WriteEndElement();

                        textWriter.WriteEndElement();


                        textWriter.WriteStartElement("Element");
                
                            textWriter.WriteAttributeString("id",null,"8");

                            textWriter.WriteStartElement("IsGood");
                                if (radioButton8Buono.Checked)
                                    textWriter.WriteString("true");
                                else if (radioButton8NonBuono.Checked)
                                    textWriter.WriteString("false");
                                else
                                    textWriter.WriteString("N/A");
                            textWriter.WriteEndElement();

                        textWriter.WriteEndElement();


                        textWriter.WriteStartElement("Element");
                
                            textWriter.WriteAttributeString("id",null,"9");

                            textWriter.WriteStartElement("IsGood");
                                if (radioButton9Buono.Checked)
                                    textWriter.WriteString("true");
                                else if (radioButton9NonBuono.Checked)
                                    textWriter.WriteString("false");
                                else
                                    textWriter.WriteString("N/A");
                            textWriter.WriteEndElement();

                        textWriter.WriteEndElement();


                        textWriter.WriteStartElement("Element");
                
                            textWriter.WriteAttributeString("id",null,"10");

                            textWriter.WriteStartElement("IsGood");
                                if (radioButton10Buono.Checked)
                                    textWriter.WriteString("true");
                                else if (radioButton10NonBuono.Checked)
                                    textWriter.WriteString("false");
                                else
                                    textWriter.WriteString("N/A");
                            textWriter.WriteEndElement();

                        textWriter.WriteEndElement();


                        textWriter.WriteStartElement("Notes");
                            textWriter.WriteString(richTextBox1.Text);
                        textWriter.WriteEndElement();


                    textWriter.WriteEndElement();

                textWriter.WriteEndDocument();
                textWriter.Close();

                this.Dispose();
            }
            catch (UnauthorizedAccessException uaex)
            {
                MessageBox.Show("Livello di autorizzazione insufficente per accedere alla cartella selezionata\nseleziona un altra cartella o esegui questo programma come amministratore\n" + uaex.StackTrace);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel salvataggio\n" + ex.StackTrace);
            }
        }

        //Chiude il form e rilascia tutte le risorse in uso
        private void buttonAnnulla_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //GUI per la selezione della directory di salvataggio
        private void buttonCartella_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                SelectSaveDirectory(folderBrowserDialog1.SelectedPath);
            }
        }

        private void buttonTastiera_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
            richTextBox1.Focus();
        }
    }
}
