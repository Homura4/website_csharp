using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using Common;

namespace website.Common.Authentication
{
    /// <summary>
    /// 验证码生成类
    /// </summary>
    public class ValidateCode
    {
        #region 计算类型的验证码生成

        /// <summary>
        /// 生成验证码(值)
        /// </summary>
        /// <param name="retInfo">验证码</param>
        /// <returns>System.String.</returns>
        public string CreateValidateCode(out string retInfo)
        {
            #region 验证码

            // 要绘制图片的值
            string retcode = "";
            // 生成的值
            retInfo = "vcode";

            #region 一个没启用的运算验证码

            //int seekSeek = unchecked((int)DateTime.Now.Ticks);
            //Random rand = new Random(seekSeek);
            //string stroper = "+-*÷";
            //string oper = stroper[rand.Next(0, stroper.Length)].ToString();
            //string k1 = string.Empty;
            //string k2 = string.Empty;

            //switch (oper)
            //{
            //    case "*":
            //        {
            //            k1 = rand.Next(1, 10).ToString();
            //            k2 = rand.Next(1, 10).ToString();
            //            retInfo = (int.Parse(k1) * int.Parse(k2)).ToString();
            //            retcode = k1 + "* " + k2 + "=?";
            //            break;
            //        }
            //    case "+":
            //        {
            //            k1 = rand.Next(1, 50).ToString();
            //            k2 = rand.Next(1, 50).ToString();
            //            retInfo = (int.Parse(k1) + int.Parse(k2)).ToString();
            //            retcode = k1 + "+ " + k2 + "=?";
            //            break;
            //        }
            //    case "-":
            //        {
            //            k1 = rand.Next(1, 50).ToString();
            //            k2 = rand.Next(1, 50).ToString();
            //            retInfo = (int.Parse(k1) - int.Parse(k2)).ToString();
            //            retcode = k1 + "- " + k2 + "=?";
            //            break;
            //        }
            //    case "÷":
            //        {
            //            k1 = rand.Next(1, 50).ToString();
            //            k2 = rand.Next(1, 50).ToString();
            //            retInfo = (int.Parse(k1) % int.Parse(k2)).ToString();
            //            retcode = k1 + "÷ " + k2 + "=?";
            //            break;
            //        }
            //}

            #endregion


            #region 字母与数字的验证码

            var vCode = Rand.Str(4);

            retInfo = vCode;
            retcode = vCode;

            #endregion

            return retcode;

            #endregion
        }

        /// <summary>
        /// 创建验证码的图片
        /// </summary>
        /// <param name="validateCode">验证码</param>
        public void CreateValidateGraphic(string validateCode)
        {
            Bitmap image = new Bitmap(110, 34);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器
                Random random = new Random();
                //清空图片背景色
                g.Clear(Color.White);

                //画图片的干扰线
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }

                Font font = new Font("Arial", 16, (FontStyle.Bold | FontStyle.Italic));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(validateCode, font, brush, 0, 3);

                //画图片的前景干扰点
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }

                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver, 4), 0, 0, image.Width - 1, image.Height - 1);
                //保存图片数据
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);

                //输出图片流
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "image/jpeg";
                HttpContext.Current.Response.BinaryWrite(stream.ToArray());
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }

        #endregion

        #region 还在写的图片验证码

        /// <summary>
        /// 获取验证图
        /// </summary>
        public void getVCodeImgBG()
        {
            Random random = new Random();
            int imgName = random.Next(1, 11);
            //读取图片
            var SourFilePath = HttpContext.Current.Server.MapPath("~/Content/Image/codeimage/" + "1" + ".png");
            //Image image = new Bitmap(SourFilePath);

            // 测试绘制
            var image = CutDiagram(SourFilePath);

            //保存图片数据
            MemoryStream stream = new MemoryStream();
            image.Save(stream, ImageFormat.Jpeg);

            //输出图片流
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "image/jpeg";
            HttpContext.Current.Response.BinaryWrite(stream.ToArray());
        }

        /// <summary>
        /// 切图
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>System.Drawing.Bitmap.</returns>
        private Bitmap CutDiagram(string file)
        {
            // 读取图片
            Image i = new Bitmap(file);
            // 随机取坐标
            Random random = new Random();

            #region 源图像位置与长宽

            // 切图思路
            // 1.工作区的长和宽由绘制长宽决定,先取随机数在来绘制
            // 2.一共三种不同工作区根据随机位置判断
            // 3.背景指定位置模糊化()

            // 图片位置定位 ps:中间大图左上角
            int ranW = random.Next(i.Width * 2 / 7, i.Width * 5 / 7);// 要计算的坐标位置以此为准
            int ranH = random.Next(i.Height / 7, i.Height * 3 / 7);
            // 要绘制的长宽
            var square = i.Width / 7; // 方
            var circular = square / 2; // 圆
            // 圆的位置随机变量,上下左右
            var circularNum = random.Next(1, 3);// 圆的数量,至少一个最多两个
            var circularNumList = new List<int>();
            for (int num = 0; num < circularNum; num++)
            {
                var isContain = true;
                do
                {
                    var position = random.Next(1, 5);
                    if (!circularNumList.Contains(position))
                    {
                        // 确定圆的数量和位置
                        circularNumList.Add(position);
                        isContain = false;
                    }
                } while (isContain);
            }
            // 圆绘制位置
            // 偏移量,由于绘制方法的因素会有1px的缝隙,确定为下方和右方
            // 考虑到美观,四个方向统一向方块偏移1xp
            var circularW = ranW + square / 4;// 横向居中
            var circularH = ranH + square / 4;// 纵向居中
            var circularUpper = ranH - circular + 1;// 上方的圆
            var circularLower = ranH + square - 2;// 下方的圆
            var circularLeft = ranW - circular + 1;// 左边的圆
            var circularRight = ranW + square - 2;// 右边的圆

            // 小图的宽和高,横纵坐标值默认为方块的值 ,小图似乎可以不考虑偏移量,先试试再说
            var minAbscissa = ranW;// 横坐标
            var minOrdinate = ranH;// 纵
            var minW = square;//长宽
            var minH = square;

            #endregion

            // 绘制拼接的图像
            Bitmap b = new Bitmap(i.Width, i.Height);
            using (Graphics g = Graphics.FromImage(b))
            {
                #region 图像绘制

                // 方块绘制
                g.DrawImage(i, new Rectangle(ranW, ranH, square, square), ranW, ranH, square, square, GraphicsUnit.Pixel);

                // 圆绘制
                // 位置矫正,似乎因为绘图方法的原因会有缝隙
                foreach (var circularItem in circularNumList)
                {
                    switch (circularItem)
                    {
                        case 1:
                            g.FillEllipse(new TextureBrush(i), circularW, circularUpper, circular, circular);// 上
                            // 小图参数
                            minH += circular;
                            minOrdinate = circularUpper;
                            break;
                        case 2:
                            g.FillEllipse(new TextureBrush(i), circularW, circularLower, circular, circular);// 下
                            // 小图参数
                            minH += circular;
                            break;
                        case 3:
                            g.FillEllipse(new TextureBrush(i), circularLeft, circularH, circular, circular);// 左
                            // 小图参数
                            minW += circular;
                            minAbscissa = circularLeft;
                            break;
                        case 4:
                            g.FillEllipse(new TextureBrush(i), circularRight, circularH, circular, circular);// 右
                            // 小圆参数
                            minW += circular;
                            break;
                    }
                }

                #endregion
            }

            //从作图区生成新图
            Image saveImage = Image.FromHbitmap(b.GetHbitmap());

            // 此处需要再度建立工作区,将绘制的图片再度截取保存为一张小图
            Bitmap bmpDest = new Bitmap(minW, minH);
            using (Graphics g = Graphics.FromImage(bmpDest))
            {
                g.DrawImage(saveImage,new Rectangle(0, 0, minW, minH), minAbscissa, minOrdinate, minW, minH, GraphicsUnit.Pixel);
            }

            Image relImage = Image.FromHbitmap(bmpDest.GetHbitmap());

            i.Dispose();

            return bmpDest;
        }

        #endregion
    }

}
