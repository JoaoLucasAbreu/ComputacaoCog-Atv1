using SkiaSharp;

namespace Projeto {
	class Program {
			static void Main(string[] args) {
			using (SKBitmap bitmapEntrada = SKBitmap.Decode("Exercicio 3.png")) {

				unsafe {
					byte* entrada = (byte*)bitmapEntrada.GetPixels();
					
					int terra = 0;
					int agua = 0;

					for (int y = 0; y < bitmapEntrada.Height; y++){
						for (int x = 0; x < bitmapEntrada.Width; x++){
							
							if (entrada[y * bitmapEntrada.Width + x] >= 127)
								terra++;
							else
								agua++;
						}
					}
					
					Console.WriteLine($"M2 de água = {agua}\nM2 de terra = {terra}");
				}	
			}

		}
	}
}
