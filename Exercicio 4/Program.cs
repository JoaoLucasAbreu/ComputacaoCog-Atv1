using SkiaSharp;

namespace Projeto {
	class Program {
		static void Main(string[] args) {

			using (SKBitmap bitmapEntrada = SKBitmap.Decode("Exercicio 4.png"), 
				bitmapSaida = new SKBitmap(new SKImageInfo(bitmapEntrada.Width, bitmapEntrada.Height, SKColorType.Gray8))) {
				
				unsafe {
					byte* entrada = (byte*)bitmapEntrada.GetPixels();					
					byte* saida = (byte*)bitmapSaida.GetPixels();
					int p = 0;

					for (int y = 0; y < bitmapEntrada.Height; y++){
						int e = (y + 1) * bitmapEntrada.Width * 4;
						for (int x = 0; x < bitmapEntrada.Width; x++, p+=4){
							saida[y * bitmapEntrada.Width + x + (bitmapEntrada.Width - (2 * x))] = (byte)((entrada[p + 2] + entrada[p + 1] + entrada[p] ) / 4);
						}
					}
				}

				using (FileStream stream = new FileStream("Exercicio 4 reverse.png", FileMode.OpenOrCreate, FileAccess.Write)) {
					bitmapSaida.Encode(stream, SKEncodedImageFormat.Png, 100);
				}
			}
		}
	}
}
