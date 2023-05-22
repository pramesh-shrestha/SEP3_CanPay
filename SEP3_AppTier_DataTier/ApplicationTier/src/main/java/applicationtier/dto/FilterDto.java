package applicationtier.dto;

public class FilterDto {
    private String date;
    private String username;

    public FilterDto(){}

    /**
     * Constructor to initialize the filter with a username and date.
     *
     * @param username The username to filter by.
     * @param date The date to filter by.
     */
    public FilterDto(String username, String date) {
        this.username = username;
        this.date = date;
    }
    /**
     * Get the username for filtering.
     *
     * @return The username.
     */
    public String getUsername () {
        return username;
    }

    /**
     * Set the username for filtering.
     *
     * @param username The username to set.
     */
    public void setUsername (String username){
        this.username = username;
    }

    /**
     * Get the date for filtering.
     *
     * @return The date.
     */
    public String getDate () {
        return date;
    }

    /**
     * Set the date for filtering.
     *
     * @param date The date to set.
     */
    public void setDate (String date){
        this.date = date;
    }

}
