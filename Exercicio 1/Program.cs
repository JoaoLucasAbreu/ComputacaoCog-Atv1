using SkiaSharp;

namespace Projeto {
	class Program {
		static void Main(string[] args) {
			using (SKBitmap bitmapEntrada = SKBitmap.Decode("Exercicio 1.png"),
				bitmapSaida = new SKBitmap(new SKImageInfo(bitmapEntrada.Width, bitmapEntrada.Height, SKColorType.Gray8))) {
				var bitmapSaidaBlue = new SKBitmap(new SKImageInfo(bitmapEntrada.Width, bitmapEntrada.Height, SKColorType.Gray8));
				var bitmapSaidaGreen = new SKBitmap(new SKImageInfo(bitmapEntrada.Width, bitmapEntrada.Height, SKColorType.Gray8));
				var bitmapSaidaRed = new SKBitmap(new SKImageInfo(bitmapEntrada.Width, bitmapEntrada.Height, SKColorType.Gray8));
				
				unsafe {
					byte* entrada = (byte*)bitmapEntrada.GetPixels();

					byte* saidaBlue = (byte*)bitmapSaidaBlue.GetPixels();
					byte* saidaGreen = (byte*)bitmapSaidaGreen.GetPixels();
					byte* saidaRed= (byte*)bitmapSaidaRed.GetPixels();

					int pixelsTotais = bitmapEntrada.Width * bitmapEntrada.Height;

					for (int x = 0, y = 0; y < pixelsTotais; x += 4, y++) {

						saidaBlue[y] = entrada[x];
						saidaGreen[y] = entrada[x + 1];
						saidaRed[y] = entrada[x + 2];

					}					
				}
					using (FileStream stream = new FileStream("blue1.png", FileMode.OpenOrCreate, FileAccess.Write)) {
						bitmapSaidaBlue.Encode(stream, SKEncodedImageFormat.Png, 100);
					}
					using (FileStream stream = new FileStream("red1.png", FileMode.OpenOrCreate, FileAccess.Write)) {
						bitmapSaidaGreen.Encode(stream, SKEncodedImageFormat.Png, 100);
					}
					using (FileStream stream = new FileStream("green1.png", FileMode.OpenOrCreate, FileAccess.Write)) {
						bitmapSaidaRed.Encode(stream, SKEncodedImageFormat.Png, 100);
					}
			}
		}
	}
}