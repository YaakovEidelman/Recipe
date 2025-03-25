import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min.js";
import Navbar from "./components/Navbar";

function App() {
    return (
        <>
            <div className="container-fluid">
                <div className="row">
                    <div className="col-12">
                        <Navbar />
                    </div>
                </div>
            </div>
        </>
    );
}

export default App;
