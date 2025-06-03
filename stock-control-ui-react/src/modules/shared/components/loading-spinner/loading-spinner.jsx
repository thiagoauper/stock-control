export default function LoadingSpinner({ loadingText }) {
    return (
        <>
            <div>
                {loadingText && <p>{loadingText}</p>}
                {!loadingText && <p>Loading...</p>}
            </div>
        </>
    );
}