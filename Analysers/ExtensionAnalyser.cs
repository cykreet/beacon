using System.IO.Compression;

class ExtensionAnalyser(WorkspaceContext context) : Analyser(context) {
	private readonly string[] allowedExtensions = [".cs", ".java", ".py"];

	public override bool Analyse() {
		foreach (ZipArchiveEntry entry in context.zipArchive.Entries) {
			if (!allowedExtensions.Contains(Path.GetExtension(entry.FullName))) return false;
		}

		return true;
	}
}