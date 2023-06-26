namespace DTP.Domain;

/// <summary>
/// ����� �� ����������� ������ �� ������ ������� � ������.
/// </summary>
public static class Converter
{
	/// <summary>
	/// ������������ ���� �� .djvu � .pdf.
	/// </summary>
	/// <param name="args">���� � ��������������� �����.</param>
	/// <exception cref="ArgumentException">�������������� ���� � ������������ �������.</exception>
	public static async Task ConvertDjvuToPdf(string[] args)
	{
		await Task.Run(() =>
		{
#if DEBUG
			const string executableFile = "template.djvu";
#else
            var executableFile = args[0];
#endif
			if (Path.GetExtension(executableFile) != ".djvu")
				throw new ArgumentException("File format must be .djvu");

			var outputFilePath = File.ConvertToPdf(executableFile);
			File.Open(outputFilePath);
		});
	}
}