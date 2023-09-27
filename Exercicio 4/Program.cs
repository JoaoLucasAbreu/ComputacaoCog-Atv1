using SkiaSharp;

namespace Projeto {
	class Program {
		static void Main(string[] args) {
			// ****************************************************************************
			// Esse código é só um começo! Você pode precisar de mais imagens de entrada,
			// ou mais imagens de saída, dependendo do exercício!
			// ****************************************************************************

			using (SKBitmap bitmap = SKBitmap.Decode("Caminho da imagem de entrada")) {
				Console.WriteLine(bitmap.ColorType);

				unsafe {

					byte* ptr = (byte*)bitmap.GetPixels();

				}

				using (FileStream stream = new FileStream("Caminho da imagem de saída", FileMode.OpenOrCreate, FileAccess.Write)) {
					bitmap.Encode(stream, SKEncodedImageFormat.Png, 100);
				}
			}
		}
	}
}
