export default function ErrorBox({ error }) {
    return (
        <div>
            <h3>Error</h3>
            {error && (
                <div>
                    <p>{error.message}</p>
                    {error.details && <pre>{error.details}</pre>}
                </div>
            )}
            {!error && <p>An unknown error occurred.</p>}
        </div>
    );
}