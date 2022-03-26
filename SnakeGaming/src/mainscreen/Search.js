function Header(props){
    return (<>
        <div id = "Header">
            {/* <div id = "search-group">
                <input
                    type= "text"
                    id = "header-search"
                    placeholder="Search..."
                    name="s"
                />
                <button type="submit">Search</button>
            </div> */}
            <h1 className = "Title">Game Browser</h1>
        </div>
    </>)
}

const filterPosts = (posts, query) => {
    if (!query) {
        return posts;
    }

    return posts.filter((post) => {
        const postName = post.name.toLowerCase();
        return postName.includes(query);
    });
};


export default Header;