using System.Diagnostics;
using SkiaSharp;

namespace Projeto {
	class Program {
			static void Main(string[] args) {
				using (SKBitmap bitmapEntrada = SKBitmap.Decode("Exercicio 3.png")) {

					unsafe {
						byte* entrada = (byte*)bitmapEntrada.GetPixels();
						
						int terra = 0;
						int agua = 0;
						int costa = 0;

						for (int y = 0; y < bitmapEntrada.Height; y++){
							for (int x = 0; x < bitmapEntrada.Width; x++){
								
								if (entrada[y * bitmapEntrada.Width + x] >= 127)
								{
									terra++;
									costa += AcharCosta(entrada, bitmapEntrada.Width, bitmapEntrada.Height, x, y);
								}
								else
									agua++;								
							}
						}
						
						Console.WriteLine($"m² de água: {agua}\nm² de terra: {terra}\nm² de costa: {costa}");
					}	
				}
		}

		static unsafe int AcharCosta(byte* entrada, int largura, int altura, int x, int y){
			 int raio = 1;

			int xInicial = x - raio;
			int yInicial = y - raio;
			int xFinal = x + raio;
			int yFinal = y + raio;

			if (xInicial < 0) {
				xInicial = 0;
			}
			if (yInicial < 0) {
				yInicial = 0;
			}
			if (xFinal > largura - 1) {
				xFinal = largura - 1;
			}
			if (yFinal > altura - 1) {
				yFinal = altura - 1;
			}

			for (y = yInicial; y <= yFinal; y++){
				for (x = xInicial; x <= xFinal; x++){
					if (entrada[y * largura + x] < 127){
						return 1;
					}
				}
			}

			return 0;
		}
	}
}
