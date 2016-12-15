using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MemoryGameProject
{
	public class CaptchaText
	{
		#region Properties

		public string Text
		{
			get { return text; }
		}
		public Bitmap Image
		{
			get { return image; }
		}
		public int Width
		{
			get { return width; }
		}
		public int Height
		{
			get { return height; }
		}

		#endregion Properties

		#region Fields

		private string text;
		private int width;
		private int height;
		private string familyName;
		private Bitmap image;
		private Random random = new Random();

		#endregion Fields

		#region Methods

		public CaptchaText(string s, int width, int height)
		{
			text = s;
			SetDimensions(width, height);
			GenerateImage();
		}

		public CaptchaText(string s, int width, int height, string familyName)
		{
			text = s;
			SetDimensions(width, height);
			SetFamilyName(familyName);
			GenerateImage();
		}

		~CaptchaText()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
			Dispose(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				image.Dispose();
			}
		}

		private void SetDimensions(int width, int height)
		{
			if (width <= 0)
			{
				throw new ArgumentOutOfRangeException("width", width, "Argument out of range,must be greater than zero.");
			}

			if (height <= 0)
			{
				throw new ArgumentOutOfRangeException("height", height, "Argument out of range,must be greater than zero.");
			}

			this.width = width;
			this.height = height;
		}

		private void SetFamilyName(string familyName)
		{
			try
			{
				Font font = new Font(this.familyName, 12F);
				this.familyName = familyName;
				font.Dispose();
			}
			catch (Exception)
			{
				this.familyName = FontFamily.GenericSerif.Name;
			}
		}

		private void GenerateImage()
		{
			Bitmap bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			Graphics g = Graphics.FromImage(bitmap);
			g.SmoothingMode = SmoothingMode.AntiAlias;
			Rectangle rect = new Rectangle(0, 0, width, height);
			HatchBrush hatchBrush = new HatchBrush(HatchStyle.SmallConfetti, Color.LightGray, Color.White);
			g.FillRectangle(hatchBrush, rect);
			SizeF size;
			float fontSize = rect.Height + 1;
			Font font;

			do
			{
				fontSize--;
				font = new Font(this.familyName, fontSize, FontStyle.Bold);
				size = g.MeasureString(text, font);
			} while (size.Width > rect.Width);

			StringFormat format = new StringFormat();
			format.Alignment = StringAlignment.Center;
			format.LineAlignment = StringAlignment.Center;
			GraphicsPath path = new GraphicsPath();

			path.AddString(text, font.FontFamily, (int)font.Style, font.Size, rect, format);
			float v = 4F;
			PointF[] points =
			{
					new PointF(this.random.Next(rect.Width) / v, this.random.Next(rect.Height) / v),
					new PointF(rect.Width - this.random.Next(rect.Width) / v, this.random.Next(rect.Height) / v),
					new PointF(this.random.Next(rect.Width) / v, rect.Height - this.random.Next(rect.Height) / v),
					new PointF(rect.Width - this.random.Next(rect.Width) / v,rect.Height - random.Next(rect.Height) / v)
				};

			Matrix matrix = new Matrix();
			matrix.Translate(0F, 0F);
			path.Warp(points, rect, matrix, WarpMode.Perspective, 0F);
			hatchBrush = new HatchBrush(HatchStyle.LargeConfetti, Color.LightGray, Color.DarkGray);
			g.FillPath(hatchBrush, path);
			int m = Math.Max(rect.Width, rect.Height);

			for (int i = 0; i < (int)(rect.Width * rect.Height / 30F); i++)
			{
				int x = random.Next(rect.Width);
				int y = random.Next(rect.Height);
				int w = random.Next(m / 50);
				int h = random.Next(m / 50);
				g.FillEllipse(hatchBrush, x, y, w, h);
			}

			font.Dispose();
			hatchBrush.Dispose();
			g.Dispose();
			image = bitmap;
		}

		#endregion Methods
	}
}
