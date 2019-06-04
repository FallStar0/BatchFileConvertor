using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatchFileConvertor
{
    public partial class Form1 : Form
    {
        private ConvertLogic logic = new ConvertLogic();

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        #region Events
        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            logic.Logger = Log;

            this.btnBrowseIn.Click += (s, e) =>
            {
                var dialog = new FolderBrowserDialog
                {
                    Description = "请选择文件路径",
                    ShowNewFolderButton = true,
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtBrowseIn.Text = dialog.SelectedPath;
                }
            };

            this.btnBrowseOut.Click += (s, e) =>
            {
                var dialog = new FolderBrowserDialog
                {
                    Description = "请选择文件路径",
                    ShowNewFolderButton = true,
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtBrowseOut.Text = dialog.SelectedPath;
                }
            };

            this.btnConfigApply.Click += (s, e) =>
            {
                Properties.Settings.Default.Save();
            };
            this.btnConfigReset.Click += (s, e) =>
            {
                Properties.Settings.Default.Reset();
                Properties.Settings.Default.Save();
            };

            btnToCHT.Click += async (s, e) => await Convert2CHT();
            btnToCHS.Click += async (s, e) => await Convert2CHS();
        }
        #endregion

        #region 转换
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool Prepare()
        {
            var prop = Properties.Settings.Default;
            var txtIn = txtBrowseIn.Text;

            if (string.IsNullOrEmpty(txtIn))
            {
                MessageBox.Show("输入路径不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(prop.OutputDir))
            {
                MessageBox.Show("输出路径不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(prop.SupportSubfix))
            {
                MessageBox.Show("支持拓展名不能为空！");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 转换为繁体
        /// </summary>
        private async Task Convert2CHT()
        {
            if (!Prepare()) return;
            txtLog.Clear();
            btnToCHS.Enabled = false;
            btnToCHT.Enabled = false;
            var prop = Properties.Settings.Default;
            var txtIn = txtBrowseIn.Text;
            try
            {
                await Task.Run(() => logic.Begin(txtIn, prop.OutputDir, logic.CHS2CHT, prop.SupportSubfix, prop.IsRecursive));
                Log($"成功转换文件：{logic.CurrentCount}个");
            }
            catch (Exception ex)
            {
                Log(ex.Message + ex.StackTrace);
                MessageBox.Show("异常：" + ex.Message);
            }
            finally
            {
                btnToCHS.Enabled = true;
                btnToCHT.Enabled = true;
            }
        }

        /// <summary>
        /// 转换为简体体
        /// </summary>
        private async Task Convert2CHS()
        {
            if (!Prepare()) return;
            txtLog.Clear();
            btnToCHS.Enabled = false;
            btnToCHT.Enabled = false;
            var prop = Properties.Settings.Default;
            var txtIn = txtBrowseIn.Text;
            try
            {
                await Task.Run(() => logic.Begin(txtIn, prop.OutputDir, logic.CHT2CHS, prop.SupportSubfix, prop.IsRecursive));
                Log($"成功转换文件：{logic.CurrentCount}个");
            }
            catch (Exception ex)
            {
                Log(ex.Message + ex.StackTrace);
                MessageBox.Show("异常：" + ex.Message);
            }
            finally
            {
                btnToCHS.Enabled = true;
                btnToCHT.Enabled = true;
            }
        }

        /// <summary>
        /// 输出日志
        /// </summary>
        /// <param name="log"></param>
        private void Log(string log)
        {
            Action<string> act = x => { txtLog.AppendText(x + Environment.NewLine); };
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(act, log);
            }
            else
            {
                act(log);
            }
        }
        #endregion
    }
}
