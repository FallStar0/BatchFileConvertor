﻿using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

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
            this.Text += " v" + SysConstants.AppVersion;
            logic.Logger = Log;
            var cfg = Properties.Settings.Default;

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
                cfg.ConvertMode = (byte)(rbSysMode.Checked ? ConvertMode.System : ConvertMode.VB);
                cfg.OutputEncoding = (byte)(rbOutputDefault.Checked ? EncodingType.Default : EncodingType.UTF8);
                cfg.Save();
            };
            this.btnConfigReset.Click += (s, e) =>
            {
                rbSysMode.Checked = true;
                rbOutputDefault.Checked = true;
                cfg.Reset();
                cfg.Save();
            };

            btnToCHT.Click += async (s, e) => await Convert2CHT();
            btnToCHS.Click += async (s, e) => await Convert2CHS();

            txtBrowseIn.DragEnter += (s, e) => e.Effect = DragDropEffects.Link;
            txtBrowseIn.DragDrop += (s, e) =>
            {
                var t = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
                if (!System.IO.Directory.Exists(t) && !System.IO.File.Exists(t)) return;
                ((TextBox)s).Text = t;
            };

            txtBrowseOut.DragEnter += (s, e) => e.Effect = DragDropEffects.Link;
            txtBrowseOut.DragDrop += (s, e) =>
            {
                var t = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
                if (!System.IO.Directory.Exists(t)) return;
                ((TextBox)s).Text = t;
            };
            var mode = (ConvertMode)cfg.ConvertMode;
            if (mode == ConvertMode.VB)
                rbVBMode.Checked = true;
            else
                rbSysMode.Checked = true;

            var enc = (EncodingType)cfg.OutputEncoding;
            if (enc == EncodingType.Default)
                rbOutputDefault.Checked = true;
            else
                rbOutputUTF8.Checked = true;

            llbGitee.LinkClicked += (s, e) => System.Diagnostics.Process.Start("https://gitee.com/fallstar/BatchFileConvertor");
            llbGithub.LinkClicked += (s, e) => System.Diagnostics.Process.Start("https://github.com/FallStar0/BatchFileConvertor");

            InitTabText();
        }

        #endregion

        #region 转换

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private ConvertContext Prepare()
        {
            var prop = Properties.Settings.Default;
            var ctx = new ConvertContext()
            {
                IsIgnoreUnchangeFile = prop.IsIgnoreUnchangeFile,
                IsRecursive = prop.IsRecursive,
                RootInputDirectory = txtBrowseIn.Text,
                RootOutputDirectory = txtBrowseOut.Text,
            };

            if (string.IsNullOrEmpty(ctx.RootInputDirectory))
            {
                MessageBox.Show("输入路径不能为空！");
                return null;
            }
            if (string.IsNullOrEmpty(ctx.RootOutputDirectory))
            {
                MessageBox.Show("输出路径不能为空！");
                return null;
            }
            if (string.IsNullOrEmpty(prop.SupportSubfix))
            {
                MessageBox.Show("支持拓展名不能为空！");
                return null;
            }

            var t = prop.IgnoreFolder;
            if (!string.IsNullOrEmpty(t))
                ctx.IgnoreFolders = t.Split(',').Where(x => !string.IsNullOrEmpty(x)).ToList();
            prop.SupportSubfix = txtSubfix.Text.Trim();
            t = prop.SupportSubfix;
            ctx.Subfix = t.Split(',').Where(x => !string.IsNullOrEmpty(x)).Select(y => y.ToLower()).ToList();

            ctx.Mode = rbVBMode.Checked ? ConvertMode.VB : ConvertMode.System;
            ctx.OutputEncoding = rbOutputDefault.Checked ? EncodingType.Default : EncodingType.UTF8;
            return ctx;
        }

        /// <summary>
        /// 转换为繁体
        /// </summary>
        private async Task Convert2CHT()
        {
            var ctx = Prepare();
            if (ctx == null) return;
            if (ctx.Mode == ConvertMode.VB)
                ctx.Convertor = logic.ToCHT;
            else
                ctx.Convertor = ChineseStringUtility.ToTraditional;
            txtLog.Clear();
            btnToCHS.Enabled = false;
            btnToCHT.Enabled = false;
            var prop = Properties.Settings.Default;
            var txtIn = txtBrowseIn.Text;
            try
            {
                await Task.Run(() => logic.Begin(ctx));
                Log($"成功转换文件：{ctx.CurrentCount}个");
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
            var ctx = Prepare();
            if (ctx == null) return;
            if (ctx.Mode == ConvertMode.VB)
                ctx.Convertor = logic.ToCHS;
            else
                ctx.Convertor = ChineseStringUtility.ToSimplified;
            txtLog.Clear();
            btnToCHS.Enabled = false;
            btnToCHT.Enabled = false;
            var prop = Properties.Settings.Default;
            var txtIn = txtBrowseIn.Text;
            try
            {
                await Task.Run(() => logic.Begin(ctx));
                Log($"成功转换文件：{ctx.CurrentCount}个");
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

        #region 文本面板
        /// <summary>
        /// 初始化面板
        /// </summary>
        private void InitTabText()
        {
            btnTextClear.Click += (s, e) => txtTextSource.Clear();
            btnTextCopy.Click += (s, e) =>
            {
                var t = txtTextTarget.Text;
                if (string.IsNullOrEmpty(t))
                    return;
                Clipboard.SetText(t);
            };
            btnTextPaste.Click += (s, e) => txtTextSource.Text = Clipboard.GetText();

            btnTextToCHT.Click += (s, e) =>
            {
                var t = txtTextSource.Text;
                if (string.IsNullOrEmpty(t)) return;
                var prop = Properties.Settings.Default;
                Func<string, string> func;
                if (prop.ConvertMode == 0)
                    func = logic.ToCHT;
                else
                    func = ChineseStringUtility.ToTraditional;
                t = func(t);
                txtTextTarget.Text = t;
            };

            btnTextToCHS.Click += (s, e) =>
            {
                var t = txtTextSource.Text;
                if (string.IsNullOrEmpty(t)) return;
                var prop = Properties.Settings.Default;
                Func<string, string> func;
                if (prop.ConvertMode == 0)
                    func = logic.ToCHS;
                else
                    func = ChineseStringUtility.ToSimplified;
                t = func(t);
                txtTextTarget.Text = t;
            };
        }
        #endregion
    }
}