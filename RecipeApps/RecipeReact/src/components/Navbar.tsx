
import "./navbar.css";
import { NavLink } from "react-router-dom";


function Navbar() {

    return (
        <>
            <nav className="navbar navbar-expand-lg navbar-light bg-light">
                <a className="navbar-brand" href="#">
                    <img src="/images/Hearty Hearth.jpg" alt="Logo" className="d-inline-block rounded-3 p-1 navbar-logo" />
                </a>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent">
                    <span className="navbar-toggler-icon"></span>
                </button>

                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav mr-auto">
                        <li className="nav-item"><NavLink to={"/recipecontent/0"} className="nav-link">Recipes</NavLink></li>
                        <li className="nav-item active"><NavLink to={"/meals"} className="nav-link">Meals</NavLink></li>
                        <li className="nav-item"><NavLink to={"/cookbooks"} className="nav-link">Cookbooks</NavLink></li>
                    </ul>
                </div>
            </nav>
        </>
    );
}

export default Navbar;
