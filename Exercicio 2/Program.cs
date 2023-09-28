using SkiaSharp;

namespace Projeto {
	class Program {
		static void Main(string[] args) {
			static unsafe int BuscaCosta(byte* entrada, int width, int height, int x , int y , int raioCosta){
				
				int x1 = x - raioCosta;
				int x2 = x + raioCosta;

				int y1 = y - raioCosta;
				int y2 = y + raioCosta;
				
				if (x1 < 0) {
					x1 = 0;
				} else if (y1 < 0) {
					y1 = 0;
				} else if (x2 > width - 1) {
					x2 = width-1;
				} else if (y2 > height - 1) {
					y2 = height - 1;
				}

				int costa = 0;

				for(y = y1; y <= y2; y++){
					for(x = x1; x <= x2; x++){
						int i = (y * width) + x;
						if( entrada[i] == 0 ){
							costa = 1;
						}
					}
				}
				return costa;
			}
															
			using (SKBitmap bitmapEntrada = SKBitmap.Decode("Exercicio 2.png")) {
				
				int width = bitmapEntrada.Width;
				int height = bitmapEntrada.Height;
				int raioCosta = 1;
				long terra = 0;
				long costa = 0;
				int pixelsTotais = bitmapEntrada.Width * bitmapEntrada.Height;

				unsafe {
					byte* entrada = (byte*)bitmapEntrada.GetPixels();
					
					for (int y = 0; y < height; y++) {
						for (int x= 0; x < width ; x++) {
							if(entrada[y * width + x ] == 255){
								terra += 1;
								costa += BuscaCosta(entrada, width,height, x, y, raioCosta);
							}
						}
					}
				}

				Console.WriteLine(pixelsTotais + "m²");
				Console.WriteLine(terra + "m²");
				Console.WriteLine(costa + "m²");

			}
		}		
	}
}
