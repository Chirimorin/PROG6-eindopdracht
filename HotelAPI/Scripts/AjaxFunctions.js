function SaveAuthToken(token) {
    localStorage.setItem("AuthToken", "bearer " + token);
}

function AddAuthToken(xhr) {
    //securityToken = "bearer dz2NEQsTf8-acj_xplOunY5PMv_9lpVXiSy7Zp1wN5I0tk6KqKTH8p6a3kvQ23-w-K_rXgITUrTXbEk6VUYfifTpWC4-L0jIHMuJ-kkNu1eEylX_achRd6_FcjBYmeeV1DfBXNLCNarpRYjQsz1RyCpyoEs9e9sUEir87UWxuBG4tAotA08s6rYGldMoUJJPNwbYOPIjEXdyrNef8uWpu5aYX1xTrZ0XUE4i17KCJyAeEWrgAD0u_0YmlYbnbTdOJQ3mGvvDAcLGVBnrWoWTXpzmBkvd0CjNlMuCt7iwxoqchRzstDYlXw4SbPWgNrCklNeUcwg_rWcH0GI0-qrZLDI59wPjYjYmnQS5JIPhVgtMA-XI6Qdo5XCh1A0Qj25HyswJrBpmqgzrv79s9-PmQOPqZRgOB9ALMtLBSUNgpS5MvMD_E4d-5beulc-XJjUJJ7HlWTYVMMsBsrLLSL1Un7i9GEu2n-Gm1mgMZoKcrmr2v4QM7Y5qAoskWjOCGK_pNKz8Zqcl7TRiFU_rJy4gWQ";
    xhr.setRequestHeader("Authorization", localStorage.getItem("AuthToken"));
}

function PrintReply(reply) {
    console.log(reply);
}

function RedirectTo(URL) {
    window.location = URL;
}
