using System.IO.Compression;

class WorkspaceContext {
	public ZipArchive zipArchive { get; }

	public WorkspaceContext(ZipArchive zipArchive) {
		this.zipArchive = zipArchive;
	}
}

abstract class Analyser(WorkspaceContext context) {
	protected WorkspaceContext context = context;

	public abstract bool Analyse();
}